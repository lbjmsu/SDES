using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

/*
 *  Desc:   This file creates a windows form that allows a user to encrypt a file using the SDES algorithm, placing all the information in the selected file into
 *              an encrypted ".sdes" file, where a key must be provided to successfully decrypt the file. This program preserves the file extension of the original file,
 *              so when the file is successfully decrypted, it retains its original extension and is ready to be opened by its associated application. Note: the original file
 *              is DELETED when it is encrypted, replaced by the new encrypted file. The same occurs during decryption. 
 *                      !!! Remember the key to your files! You have one chance to decrypt successfully! !!!
 *  By:     Larry Johnson
 *  Date:   4/17/23 - 4/26/23
 */

namespace CS_485_Project_2
{
    public partial class SDESForm : Form
    {
        //  Initialize class variables
        //
        //  inputKey stores the key provided by the user for use in encryption/decryption
        private int inputKey;

        //  WinForms constructor
        public SDESForm()
        {
            InitializeComponent();
        }

        //  Functions

        #region Encryption/Decryption Functions

        //  Encrypt() takes the file name from the openDialog control and with that creates a new file to write binary into. The bytes written into this file will be the
        //      encrypted equivalent to each byte in the original document, selected by the openDialog control.
        private void Encrypt()
        {
            //  Initialize local variable
            string fileName = fileLocLabel.Text;
            string oldFileExtension;

            //  Generate subkeys from the user "key" input
            BitArray[] subkeys = CreateSubkeys(encryptKeyBox.Text);

            //  If the subkeys generated were not generated correctly, i.e., the user-provided key was invalid, return.
            if (subkeys.Length == 0)
            {
                encryptKeyBox.Text = "";
                return;
            }

            //  Instantiate a BinaryReader object reading from the selected file
            using (BinaryReader input = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                //  oldFileExtension saves the fileExtension of the file so that it can be written into the encrypted file and restored upon decryption.
                try
                {
                    oldFileExtension = fileName.Substring(fileName.LastIndexOf('.'));
                }
                catch(Exception)
                {
                    oldFileExtension = "";
                }

                //  Instantiate a BinaryWriter object writing to this new encrypted file, with the file extension ".sdes" showing its usage of SDES encryption.
                using (BinaryWriter output = new BinaryWriter(File.Open(fileName.Substring(0,fileName.Length - oldFileExtension.Length) + "_Encrypted.sdes", FileMode.Create)))
                {
                    //  Write the old file extension at the beginning of the file.
                    foreach(char character in oldFileExtension.Reverse())
                    {
                        output.Write(EncryptByte(Convert.ToByte(character), subkeys));
                    }

                    //  Read every byte in the file, and write the encrypted equivalent
                    bool endOfFile = false;
                    while (endOfFile == false)
                    {
                        //  Try to read a byte. If the end of the file is reached, break from the while loop.
                        try
                        {
                            byte outByte = EncryptByte(input.ReadByte(), subkeys);

                            output.Write(outByte);
                        }
                        //  EndOfStreamException is thrown when the BinaryReader attempts to read from an empty stream.
                        catch (EndOfStreamException)
                        {
                            MessageBox.Show("The file has been successfully encrypted using key: " + inputKey);
                            endOfFile = true;
                        }
                    }
                }
            }

            //  After encrypting, delete the file and make the file location label invisible to signal that.
            File.Delete(fileName);
            fileLocLabel.Visible = false;

            //  Clear the key for security purposes. The user should have remembered this.
            encryptKeyBox.Text = "";

            //  Disable the encrypt panel so the user cannot encrypt a file that no longer exists.
            encryptPanel.Enabled = false;
        }

        //  EncryptByte(byte, BitArray[]) encrypts a byte using the SDES algorithm. 
        private byte EncryptByte(byte byteInput, BitArray[] subkeys)
        {
            //  Using an input byte and subkeys, create a ciphertext byte. (This could theoretically be one line, but that would be a very complex line)
            BitArray inByteToBitArray = IntToBitArray(byteInput);
            BitArray inByteAfterPermutation = SDESPermutation(inByteToBitArray);
            BitArray inByteAfterFK1 = FK(inByteAfterPermutation, subkeys[0]);
            BitArray inByteSwapAfterFK1 = SwitchHalves(inByteAfterFK1);
            BitArray inByteAfterFK2 = FK(inByteSwapAfterFK1, subkeys[1]);
            BitArray outByte = SDESPermutation(inByteAfterFK2, true);

            //  Return the ciphertext byte.
            return (byte)BitArrayToInt(outByte);
        }

        //  Decrypt() takes an encrypted ".sdes" file and decrypts it using the inverse of the SDES algorithm
        private void Decrypt()
        {
            //  Initialize local variable
            string fileName = fileLocLabel.Text;

            //  Generate subkeys from the user "key" input
            BitArray[] subkeys = CreateSubkeys(decryptKeyBox.Text);

            //  If the subkeys generated were not generated correctly, i.e., the user-provided key was invalid, return.
            if (subkeys.Length == 0)
            {
                decryptKeyBox.Text = "";
                return;
            }

                //  Initialize a BinaryReader object to read from the file selected by the user
            using (BinaryReader input = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                //  Initialize variables needed to read and store the file extension of the original file
                string oldFileExtensionReversed = "";
                string oldFileExtension = "";
                char currentChar;
                bool nonAlphaNumericFlag = false;

                //  If the same SDES software was used to encrypt the file, telling the program that the necessary file formatting was used,
                if (sameEncryptionSoftwareCheckBox.Checked)
                {
                    //  Read up until the first period is reached in plaintext. The read bytes will be deciphered as such. Add each character to an array that will
                    //      later be reversed, as the file extension was stored in reverse to allow separation from the rest of the data based on the period character.
                    do
                    {
                        currentChar = (char)DecryptByte(input.ReadByte(), subkeys);
                        oldFileExtensionReversed += currentChar;

                    } while (currentChar != '.');

                    //  Flip the fileExtension string so that it can be used to create the file that will be written into. If there is a character before the first period
                    //      that is not alphanumeric, an error has occurred, and the new file will now be written without a file extension.
                    foreach (char character in oldFileExtensionReversed.Reverse())
                    {
                        oldFileExtension += character;
                        if (!Char.IsLetterOrDigit(character) && character != '.')
                        {
                            nonAlphaNumericFlag = true;
                        }
                    }
                }

                //  A different software was used, so the file very likely does not store the old file extension in the beginning of the file like this program does.
                else
                {
                    nonAlphaNumericFlag = true;
                }

                //  Instantiate a BinaryWriter object open to the name of the original file + "Decrypted" at the end. As mentioned above, if an error occurred
                //      in parsing the file's extension, do not create a file with an extension.
                using (BinaryWriter output = new BinaryWriter(File.Open(fileName.Substring(0, fileName.LastIndexOf('_')) + (!nonAlphaNumericFlag ? oldFileExtension : ""), FileMode.Create)))
                {
                    //  If the input was incorrect, return without reading.
                    if (subkeys == new BitArray[] { })
                    {
                        return;
                    }

                    //  Read every byte in the file, and write the encrypted equivalent
                    bool endOfFile = false;
                    while (endOfFile == false)
                    {
                        //  Try to read a byte. If the end of the file is reached, break from the while loop.
                        try
                        {
                            byte outByte = DecryptByte(input.ReadByte(), subkeys);

                            output.Write(outByte);
                        }
                        //  EndOfStreamException is thrown when the BinaryReader attempts to read from an empty stream.
                        catch (EndOfStreamException)
                        {
                            MessageBox.Show("The file has been decrypted using key: " + inputKey);
                            endOfFile = true;
                        }
                    }
                }
            }

            //  After decrypting, delete the file and make the file location label invisible to signal that.
            File.Delete(fileName);
            fileLocLabel.Visible = false;

            //  Clear the key for security purposes.
            decryptKeyBox.Text = "";

            //  Disable the decrypt panel so the user cannot decrypt a file that no longer exists.
            decryptPanel.Enabled = false;
        }

        //  DecryptByte(byte, BitArray[]) decrypts a byte using the SDES algorithm. 
        private byte DecryptByte(byte byteInput, BitArray[] subkeys)
        {
            //  Using the SDES algorithm, convert from ciphertext to plaintext.
            BitArray inByteToBitArray = IntToBitArray(byteInput);
            BitArray inByteAfterPermutation = SDESPermutation(inByteToBitArray);
            BitArray inByteAfterFK1 = FK(inByteAfterPermutation, subkeys[1]);
            BitArray inByteSwapAfterFK1 = SwitchHalves(inByteAfterFK1);
            BitArray inByteAfterFK2 = FK(inByteSwapAfterFK1, subkeys[0]);
            BitArray outByte = SDESPermutation(inByteAfterFK2, true);

            //  Return the result of the SDES decryption.
            return (byte)BitArrayToInt(outByte);
        }

        #endregion

        #region Key Generation Functions

        //  CreateSubkeys:
        //  The overarching function creating the keys for use in S-DES
        private BitArray[] CreateSubkeys(string readFrom, bool binaryInput = false, bool showData = false)
        {
            //  Key Input validation
            //
            //  If the input is not a number, or this inputKey is greater than 2^10 - 1 or less than 0, inform the user that an invalid key was entered.
            if (!binaryInput)
            {
                if (!Int32.TryParse(readFrom, out inputKey) || inputKey > 1023 || inputKey < 0)
                {
                    MessageBox.Show("Please enter a number between 0 and 1023.");
                    return new BitArray[0];
                }
            }
            else
            {
                if(StringToBitArray(readFrom) != new BitArray(0))
                {
                    inputKey = BitArrayToInt(StringToBitArray(readFrom));
                }
                //      MessageBox.Show("Key = " + BitArrayToString(StringToBitArray(readFrom)) + " = " + inputKey);
            }

            //  Create subkeys from the initial key provided by the user
            BitArray inputBits = IntToBitArray(inputKey, 10);
            BitArray p10Bits = P10Swap(inputBits);
            BitArray key1 = P8KeyGeneration(p10Bits);
            BitArray key2 = P8KeyGeneration(DoubleCircularLeftShift(p10Bits));

            //  If this function was called with the showData bool set to true, update data in the subKey boxes (currently invisible).
            if (showData)
            {
                subKey1Box.Text = BitArrayToString(key1);
                subKey2Box.Text = BitArrayToString(key2);
            }

            //  Return the keys.
            return new BitArray[] { key1, key2 };
        }

        //  P10Swap:
        //  Performs the P10Swap, including both the Permutation and the circular bit shift on each part
        private BitArray P10Swap(BitArray inBitArr)
        {
            //  Initialize local variables
            int[] swaps = {3, 5, 2, 7, 4, 10, 1, 9, 8, 6};
            BitArray toReturnPart1 = new BitArray(5, false);
            BitArray toReturnPart2 = new BitArray(5, false);

            //  Bit shift left the first 5 bits of the input key after permutation
            for(int i = 0; i < 5; i++)
                toReturnPart1.Set(i, inBitArr[swaps[i] - 1]);
            BitArray toReturnPart1Shifted = CircularBitShift(toReturnPart1);

            //  Do the same for the second 5 bits
            for (int i = 5; i < 10; i++)
                toReturnPart2.Set(i-5, inBitArr[swaps[i] - 1]);
            BitArray toReturnPart2Shifted = CircularBitShift(toReturnPart2);

            //  Return finished swap
            return CombineArrays(toReturnPart1Shifted, toReturnPart2Shifted);
        }

        //  P8KeyGeneration:
        //  Performs the permutation of the bits created during the P10 swap to create the first key, and is used alongside the double circular bit shift
        //      to create the second subkey
        private BitArray P8KeyGeneration(BitArray inBitArr)
        {
            //  Initialize local variables
            int[] outBits = { 6, 3, 7, 4, 8, 5, 10, 9 };
            BitArray toReturn = new BitArray(8, false);

            //  Permute bits from inBitArr
            for (int i = 0; i < toReturn.Length; i++)
                toReturn.Set(i, inBitArr[outBits[i] - 1]);

            //  Return finalized 8-bit BitArray
            return toReturn;
        }

        //  CircularBitShift:
        //  Performs a circular bit shift on a BitArray in either direction determined by the left parameter
        private BitArray CircularBitShift(BitArray inBitArr, bool left = true)
        {
            //  Create local variable
            BitArray toReturn = new BitArray(inBitArr.Length);

            //  Shifts the inBitArray left
            if (left)
            {
                for (int i = 1; i < inBitArr.Length; i++)
                    toReturn.Set(i - 1, inBitArr[i]);

                toReturn.Set(inBitArr.Length-1, inBitArr[0]);
            }

            //  Shifts the inBitArray right
            else
            {
                for (int i = 0; i < inBitArr.Length - 1; i++)
                    toReturn.Set(i + 1, inBitArr[i]);

                toReturn.Set(0, inBitArr[inBitArr.Length-1]);
            }

            //  Return the shifted array
            return toReturn;
        }

        //  DoubleCircularLeftShift:
        //  Performs the double Circular Left Shift on both subarrays as required to create subkey 2
        private BitArray DoubleCircularLeftShift(BitArray inBitArr)
        {
            BitArray inBitArrPart1 = SubArray(inBitArr, 5);
            BitArray inBitArrPart2 = SubArray(inBitArr, 10, 5);

            return CombineArrays(CircularBitShift(CircularBitShift(inBitArrPart1)), CircularBitShift(CircularBitShift(inBitArrPart2)));
        }

        #endregion

        #region SDES Functions
        //  SDESPermutation:
        //  Performs both the forward and inverse permutation required by the SDES algorithm
        private BitArray SDESPermutation(BitArray inBitArr, bool inverse = false)
        {
            int[] swapToLocations = { 2, 6, 3, 1, 4, 8, 5, 7 };
            BitArray toReturn = new BitArray(inBitArr.Length, false);

            //  If not doing the inverse, set the values in swapToLocations in
            //      ascending order, randomly accessing the inBitArr BitArray
            if(!inverse)
            {
                for(int i = 0; i < inBitArr.Length; i++)
                {
                    toReturn.Set(i, inBitArr[swapToLocations[i] - 1]);
                }
            }

            //  If doing the inverse, do the opposite, and iterate through
            //      the inBitArr BitArray sequentially, setting them in random
            //      access to the return array. This essentially changes the
            //      input to the output, and reverses the process.
            else
            {
                for (int i = 0; i < inBitArr.Length; i++)
                {
                    toReturn.Set(swapToLocations[i] - 1, inBitArr[i]);
                }
            }

            return toReturn;
        }

        //  FK:
        //  FK is a function that combines substitutions and permutations
        //      to make nearly arbitrary the process to translate from input
        //      to output. (Encryption strength)
        private BitArray FK(BitArray inBitArr, BitArray key)
        {
            //  Initialize local variables
            //  lHalf and rHalf split the input BitArray into two halves, as the output of FK is (lHalf, lhalf XOR F(rHalf, key))
            BitArray lHalf = SubArray(inBitArr, 4);
            BitArray rHalf = SubArray(inBitArr, inBitArr.Length, 4);

            //  XOR with the right half mapped to the current subkey as described by the FMapping function.
            lHalf = lHalf.Xor(FMapping(rHalf, key));

            //  Return the combination of the two arrays
            return CombineArrays(lHalf, rHalf);
        }

        //  FMapping:
        //  Subfunction for FK which creates a new 4-bit array given a 4-bit array
        //      and a key.
        private BitArray FMapping(BitArray inBitArr, BitArray key)
        {
            //  Initialize local variables
            int[] locationArray = { 4, 1, 2, 3, 2, 3, 4, 1 };
            int[] P4LocationArray = { 2, 4, 3, 1 };
            BitArray XORBitArray = new BitArray(8, false);
            BitArray P4Result = new BitArray(4, false);
            BitArray toReturn = new BitArray(4, false);
            int[][] S0 = {  new int[] {1, 0, 3, 2},
                            new int[] {3, 2, 1, 0},
                            new int[] {0, 2, 1, 3},
                            new int[] {3, 1, 3, 2}  };
            int[][] S1 = {  new int[] {0, 1, 2, 3},
                            new int[] {2, 0, 1, 3},
                            new int[] {3, 0, 1, 0},
                            new int[] {2, 1, 0, 3}  };

            //  Expand the input BitArray and XOR that with the current subkey
            for (int i = 0; i < locationArray.Length; i++)
            {
                XORBitArray.Set(i, inBitArr[locationArray[i] - 1]);
            }
            XORBitArray.Xor(key);

            //  Use the S0 and S1 2D arrays to get the return values. The first four bits in XORBitArray will be processed as the first two bits in the output array,
            //  and the second four bits of XORBitArray as the second two bits in the output array.
            for(int i = 0; i < 2; i++)
            {
                BitArray rowBitArray = new BitArray(2, false);
                BitArray columnBitArray = new BitArray(2, false);
                BitArray halfOfReturnArray;

                rowBitArray.Set(0, XORBitArray[0 + i * 4]);
                rowBitArray.Set(1, XORBitArray[3 + i * 4]);

                columnBitArray.Set(0, XORBitArray[1 + i * 4]);
                columnBitArray.Set(1, XORBitArray[2 + i * 4]);

                int row = BitArrayToInt(rowBitArray);
                int column = BitArrayToInt(columnBitArray);

                if (i == 0)
                {
                    halfOfReturnArray = IntToBitArray(S0[row][column], 2);
                }
                else
                {
                    halfOfReturnArray = IntToBitArray(S1[row][column], 2);
                }

                for(int j = 0; j < 2; j++)
                {
                    P4Result.Set(j + i * 2, halfOfReturnArray[j]);
                }
            }

            //  Permute the values in P4Result as according to the SDES algorithm and return this new BitArray
            for(int i = 0; i < 4; i++)
            {
                toReturn.Set(i, P4Result[P4LocationArray[i] - 1]);
            }
            return toReturn;
        }

        #endregion

        #region BitArray Operation Functions
        //  SubArray:
        //  Returns a BitArray with values from startIndex up to but not including endIndex
        private BitArray SubArray(BitArray inBitArr, int endIndex, int startIndex = 0)
        {
            BitArray toReturn = new BitArray(endIndex - startIndex, false);

            for (int i = startIndex; i < endIndex; i++)
                toReturn.Set(i - startIndex, inBitArr[i]);

            return toReturn;
        }

        //  CombineArrays:
        //  Combines two BitArrays
        private BitArray CombineArrays(BitArray inBitArr1, BitArray inBitArr2)
        {
            BitArray toReturn = new BitArray(inBitArr1.Length + inBitArr2.Length, false);

            for (int i = 0; i < inBitArr1.Length; i++)
                toReturn.Set(i, inBitArr1[i]);

            for (int i = 0; i < inBitArr2.Length; i++)
                toReturn.Set(i + inBitArr1.Length, inBitArr2[i]);

            return toReturn;
        }

        //  IntToBitArray:
        //  Turns an int into its corresponding BitArray
        private BitArray IntToBitArray(int input, int initialArraySize = 8)
        {
            //  Input validation: The user specifies the size of BitArray that they want, so the input integer must be less than 2^initialArraySize - 1
            if (input > Math.Pow(2, initialArraySize))
            {
                throw new Exception("Input key too large" +
                    " -- choose a value below " + Math.Pow(2, initialArraySize) + "." );
            }

            //  For every bit in the BitArray, test to see if it should be filled, from MSB to LSB.
            BitArray toReturn = new BitArray(initialArraySize, false);

            int powOfTwo;
            for (int arraySize = initialArraySize; arraySize > 0; arraySize--)
            {
                powOfTwo = Convert.ToInt32(Math.Pow(2, arraySize - 1));

                //  If successful, remove 2^(the bit location) from the input integer.
                if (input % powOfTwo != input)
                {
                    toReturn.Set(initialArraySize - arraySize, true);
                    input -= powOfTwo;
                }
            }

            return toReturn;
        }

        //  BitArrayToInt:
        //  Turns a BitArray into its integer representation
        private int BitArrayToInt(BitArray inBitArr)
        {
            double toReturn = 0;

            for(int i = 0; i < inBitArr.Length; i++)
            {
                if (inBitArr[i] == true)
                {
                    toReturn += Math.Pow(2, inBitArr.Length - i - 1);
                }
            }

            return (int)toReturn;
        }

        //  BitArrayToString:
        //  Turns a bit array into its string representation
        private string BitArrayToString(BitArray bitArray)
        {
            string returnString = "";

            foreach (bool b in bitArray)
                returnString += b ? "1" : "0";

            return returnString;
        }

        //  StringToBitArray:
        //  Turns a string into a BitArray. If this isn't possible, then an empty BitArray is returned.
        private BitArray StringToBitArray(string inString)
        {
            BitArray toReturn = new BitArray(inString.Length, false);

            for(int i = 0; i < toReturn.Length; i++)
            {
                if (inString[i] == '0')
                    toReturn.Set(i, false);
                else if (inString[i] == '1')
                    toReturn.Set(i, true);
                else
                    return new BitArray(0);
            }

            return toReturn;
        }

        //  SwitchHalves:
        //  SwitchHalves simply swaps the two halves of a BitArray
        /// <summary>
        /// Returns a BitArray with the input BitArray's halves swapped. Returns an empty BitArray if the input BitArray is of odd length.
        /// </summary>
        private BitArray SwitchHalves(BitArray inBitArr)
        {
            if (inBitArr.Length % 2 != 0)
                return new BitArray(0);
            return (CombineArrays(
                SubArray(inBitArr, inBitArr.Length, inBitArr.Length / 2),
                SubArray(inBitArr, inBitArr.Length / 2)));
        }

        #endregion

        #region Event Handlers

        //  chooseFileButton_Click:
        //  This event handler opens a file dialog for the user to select a file. This file is stored in fileLocLabel and can now be encrypted or decrypted.
        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialogBox.ShowDialog() == DialogResult.OK)
            {
                fileLocLabel.Text = openFileDialogBox.FileName;
                fileLocLabel.Visible = true;
            }
        }

        //  createSubkeys_Click:
        //  The event handler controlled by the createSubkeys button, which calls
        //      the CreateSubkeys function to fill textBox controls.
        private void createSubkeys_Click(object sender, EventArgs e)
        {
            CreateSubkeys(encryptKeyBox.Text, false, true);
        }

        //  encryptFileButton_Click:
        //  Calls the Encrypt() function which encrypts the file stored in fileLocLabel
        private void encryptFileButton_Click(object sender, EventArgs e)
        {
            if (!fileLocLabel.Visible)
                return;
            try
            {
                Encrypt();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //  decryptButton_Click:
        //  Calls the Decrypt() function which decrypts the file stored in fileLocLabel
        private void decryptButton_Click(object sender, EventArgs e)
        {
            if (!fileLocLabel.Visible)
                return;
            try
            {
                Decrypt();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //  fileSelectedByUser:
        //  When the user selectes a file, enable either the encrypt panel or the decrypt panel dependent on whether the loaded file has been encrypted
        //      (denoted by if the name of the file contains the string "Encrypted.sdes").
        private void fileSelectedByUser(object sender, EventArgs e)
        {
            if (fileLocLabel.Text.Contains("Encrypted.sdes"))
            {
                decryptPanel.Enabled = true;
                encryptPanel.Enabled = false;

                encryptKeyBox.Text = "";
                subKey1Box.Text = "";
                subKey2Box.Text = "";

                return;
            }

            decryptPanel.Enabled = false;
            encryptPanel.Enabled = true;

            decryptKeyBox.Text = "";
        }

        //  encryptByteButton_Click:
        //  Encrypts the byte in encryptPlaintextBox and places the output byte in encryptCiphertextBox.
        private void encryptByteButton_Click(object sender, EventArgs e)
        {
            //  Input validation. If either the input into the key textbox or the plaintext textbox are invalid, cancel and return.
            if (byteKeyTextBox.Text.Length != 10 || StringToBitArray(byteKeyTextBox.Text).Length == 0)
            {
                MessageBox.Show("Please enter a binary key of length 10 into the byte key textbox.");
                return;
            }
            if(encryptPlaintextBox.Text.Length != 8 || StringToBitArray(encryptPlaintextBox.Text).Length == 0)
            {
                MessageBox.Show("Please enter a binary string of length 8 into the plaintext text box.");
                return;
            }

            try
            {
                byte encryptedByte = EncryptByte(Convert.ToByte(encryptPlaintextBox.Text, 2), CreateSubkeys(byteKeyTextBox.Text, true));

                encryptCipherTextBox.Text = BitArrayToString(IntToBitArray(encryptedByte));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        //  decryptByteButton_Click:
        //  Decrypts the byte in decryptCiphertextBox and places the output byte in decryptPlaintextBox.
        private void decryptByteButton_Click(object sender, EventArgs e)
        {
            //  Input validation. If either the input into the key textbox or the ciphertext textbox are invalid, cancel and return.
            if (byteKeyTextBox.Text.Length != 10 || StringToBitArray(byteKeyTextBox.Text).Length == 0)
            {
                MessageBox.Show("Please enter a binary key of length 10 into the byte key textbox.");
                return;
            }
            if (decryptCiphertextBox.Text.Length != 8 || StringToBitArray(decryptCiphertextBox.Text).Length == 0)
            {
                MessageBox.Show("Please enter a binary string of length 8 into the ciphertext text box.");
                return;
            }

            try
            {
                byte decryptedByte = DecryptByte(Convert.ToByte(decryptCiphertextBox.Text, 2), CreateSubkeys(byteKeyTextBox.Text, true));

                decryptPlaintextBox.Text = BitArrayToString(IntToBitArray(decryptedByte));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //  exitToolStripMenuItem_Click:
        //  Exits the application.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion
    }
}
