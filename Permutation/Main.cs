
using System;
using System.Linq;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace Permutation {
    public partial class frmPerm : Form
    {
        int factors = 0;
        int _wordCharIndex = 0;
        int _dynamicCheckboxCurrentY = 40;
        HttpClient _httpClient;

        public frmPerm()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private async void btnPer_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPer.Text) && ValidInput(txtPer.Text))
            {
                string[] permutations = GetPermutations(txtPer.Text.ToString());
                AddArrayItemsToListBox(permutations);

                lstAllPermutations.Items.Add("-----------------------------------------");
                lstAllPermutations.Items.Add("Permutations =  " + permutations.Length);
                lstAllPermutations.Items.Add("-------------------------------------------");

                if (HasDuplicates(permutations))
                {
                    lstAllPermutations.Items.Add("Two or more of same letter in input string");
                }

                IProgress<string> currentWordProgress = new Progress<string>(currentWord =>
                {
                    lblCurrentWordSearched.Text = currentWord;
                });

                var foundList = await Task.Run(() => FindAllThatExistInDictionary(permutations, currentWordProgress));

                lblCurrentWordSearched.Text = "Search Complete";

                foreach (var word in foundList)
                {
                    lstDictionaryWords.Items.Add(word);
                }
            }
            else
            {
                lstAllPermutations.Items.Add("------------------------------------------------");
                txtPer.Clear();
                lstAllPermutations.Items.Add("Enter more than one character");
                lstAllPermutations.Items.Add("---------------------------------------------------");
            }
        }

        private void AddArrayItemsToListBox(string[] array)
        {
            for (int i = 0; i <= array.Length - 1; i++)
            {
                if (!string.IsNullOrEmpty(array[i]))
                    lstAllPermutations.Items.Add(array[i]);
            }
        }

        private bool HasDuplicates(string[] permArray)
        {
            for (int outer = 0; outer <= permArray.Length - 1; outer++)
            {
                for (int inner = outer + 1; inner <= permArray.Length - 1; inner++)
                {
                    if (permArray[outer].Equals(permArray[inner]))
                        return true;
                }
            }
            return false;
        }

        private string[] GetPermutations(string inputString)
        {
            char[] inputCharArray = inputString.ToCharArray();
            string subString;
            string[] subStrings = new string[1000000];
            int subIndex = 0;
            int first = inputString.Length - 2;
            int second = first + 1;

            for (int count = 0; count < 2; count++)
            {
                inputCharArray = Swap(first, second, ref inputCharArray);
                subString = new string(inputCharArray).Substring(inputString.Length - 2, 2);
                subStrings[subIndex] = subString;
                subIndex++;
            }

            for (int prevLetter = inputString.Length - 3; prevLetter >= 0; prevLetter--)
            {
                string tempLetter = inputCharArray[prevLetter].ToString();
                Factorial(inputString.Length - (prevLetter + 1));
                int tempIndex = subIndex;

                for (int subs = subIndex - factors; subs < tempIndex; subs++)
                {
                    subString = tempLetter.Insert(1, subStrings[subs]);
                    subStrings[subIndex] = subString;
                    subIndex++;
                }

                char[] savedArray = new char[subStrings[subIndex - 1].Length];
                char[] tempArray = new char[subStrings[subIndex - 1].Length];
                int anotherTempIndex = subIndex;

                for (int subs = subIndex - factors; subs < anotherTempIndex; subs++)
                {
                    savedArray = subStrings[subs].ToCharArray();
                    tempArray = subStrings[subs].ToCharArray();
                    string savedString = new string(savedArray);
                    string tempString;

                    for (int swaps = 1; swaps <= tempArray.Length - 1; swaps++)
                    {
                        Swap(0, swaps, ref tempArray);
                        tempString = new string(tempArray);
                        subStrings[subIndex] = tempString;
                        subIndex++;
                        tempArray = savedString.ToCharArray();
                    }
                }
            }

            Factorial(inputString.Length);
            int startOfFinalStrings = (subStrings.Count(s => s != null) - factors);
            int finalCount = (subStrings.Count(s => s != null) - startOfFinalStrings);
            string[] outputStrings = new string[finalCount];
            int outputCounter = 0;

            for (int swapOver = startOfFinalStrings; swapOver < subIndex; swapOver++)
            {
                outputStrings[outputCounter] = subStrings[swapOver];
                outputCounter++;
            }

            return outputStrings;
        }

        private char[] Swap(int one, int two, ref char[] charArray)
        {
            char temp = charArray[one];
            charArray[one] = charArray[two];
            charArray[two] = temp;
            return charArray;
        }

        private void Factorial(int input)
        {
            if (input == 1 || input == 0)
                factors = 1;
            else
            {
                Factorial(input - 1);
                factors = factors * (input);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstAllPermutations.Items.Clear();
            lstDictionaryWords.Items.Clear();
            txtPer.Clear();
            lblCurrentWordSearched.Text = "-------------";
        }

        private bool ValidInput(string input)
        {
            if (input.Length < 2)
            {
                return false;
            }
            else { return true; }
        }

        private async void btnFindWord_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPer.Text) && ValidInput(txtPer.Text))
            {
                bool wordFound = await GetWordFromDictionaryApi(txtPer.Text);

                if (wordFound)
                {
                    lblCurrentWordSearched.Text = $"{txtPer.Text} was found";
                }
                else
                {
                    lblCurrentWordSearched.Text = $"{txtPer.Text} was not found";
                }
            }
            else
            {
                MessageBox.Show("Word is not valid");
            }
        }

        private List<string> FindAllThatExistInDictionary(string[] permutations, IProgress<string> currentWordProgress)
        {
            List<string> foundList = [];

            foreach (var permutation in permutations)
            {
                currentWordProgress.Report(permutation);

                if (permutation == "warded")
                {
                    foundList.Add(permutation);
                }

                bool wordFound = GetWordFromDictionaryApi(permutation).Result;

                if (wordFound)
                {
                    foundList.Add(permutation);
                }
            }

            return foundList;
        }

        private async Task<bool> GetWordFromDictionaryApi(string word)
        {
            try
            {
                using HttpResponseMessage response = await _httpClient.GetAsync(
                    $"https://dictionaryapi.com/api/v3/references/collegiate/json/{word}?key=a09970c7-421c-4da1-b696-922bbbad77ed");
                response.EnsureSuccessStatusCode();
                var responseStr = await response.Content.ReadAsStringAsync();
                var jsonNode = JsonNode.Parse(responseStr);

                try
                {
                    var idNode = jsonNode[0][0][0];
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            catch (HttpRequestException)
            {
                return false;
            }
        }

        private void txtPer_TextChanged(object sender, EventArgs e)
        {
            if (txtPer.Text.All(char.IsLetterOrDigit))
            {
                CheckBox checkBox = new()
                {
                    Name = "wordChar_" + _wordCharIndex,
                    Text = txtPer.Text.Substring(txtPer.Text.Length - 1),
                    Location = new System.Drawing.Point(685, _dynamicCheckboxCurrentY),
                    Font = new System.Drawing.Font("Calibri", 14)
                };

                checkBox.Click += (sender, e) =>
                {
                    MessageBox.Show(checkBox.Name);
                };

                this.Controls.Add(checkBox);
                _wordCharIndex++;
                _dynamicCheckboxCurrentY += 20;
            }
        }
    }
}
