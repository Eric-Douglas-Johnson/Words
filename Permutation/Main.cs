
using System;
using System.Linq;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Web;
using System.Text;

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

        private async void btnFindAll_Click(object sender, EventArgs e)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            if (!ValidInput(txtWord.Text)) 
            {
                MessageBox.Show("Word is empty or not valid");
                return;
            }

            IProgress<string> currentWordProgress = new Progress<string>(currentWord =>
            {
                lblCurrentWordSearched.Text = currentWord;
            });

            List<string[]> permuationsList;

            if (!string.IsNullOrEmpty(txtLetterPosition.Text) && !string.IsNullOrEmpty(txtSubtitutionLetters.Text))
            {
                permuationsList = await Task.Run(() => GetPermutationsWithSubstitutions());
            }
            else
            {
                string[] singleWordPermutations = await Task.Run(() => GetPermutations(txtWord.Text.ToString()));
                AddArrayItemsToListBox(singleWordPermutations);
                permuationsList = new List<string[]>() { singleWordPermutations };
            }

            var foundList = await Task.Run(() => FindAllThatExistInDictionary(permuationsList, currentWordProgress));

            lblCurrentWordSearched.Text = "Search Complete";

            foreach (var word in foundList)
            {
                lstDictionaryWords.Items.Add(word);
            }

            stopWatch.Stop();
            lblRunTime.Text = stopWatch.Elapsed.ToString();
        }

        private List<string[]> GetPermutationsWithSubstitutions()
        {
            if (!int.TryParse(txtLetterPosition.Text, out var letterPos)) { throw new Exception("Letter Position is not valid"); }
            if (letterPos > txtWord.Text.Length) { throw new Exception("Letter position is out of bounds"); }

            var permutationsList = new List<string[]>();
            var letterIndex = letterPos - 1;
            var subLetters = txtSubtitutionLetters.Text.Split(',');
            var wordList = new List<string>();
            wordList.Add(txtWord.Text);
            StringBuilder tempWord = new(txtWord.Text);

            foreach (var letter in subLetters)
            {
                if (!string.IsNullOrWhiteSpace(letter))
                {
                    tempWord[letterIndex] = char.Parse(letter);
                    wordList.Add(tempWord.ToString());
                }
            }

            foreach (var word in wordList)
            {
                var wordPermutations = GetPermutations(word);
                AddArrayItemsToListBox(wordPermutations);
                permutationsList.Add(wordPermutations);
            }

            return permutationsList;
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
            string[] subStrings = new string[100 * 100 * 100 * 10];
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
            txtWord.Clear();
            lblCurrentWordSearched.Text = "-------------";
        }

        private bool ValidInput(string input)
        {
            if (string.IsNullOrEmpty(input)) return false;

            if (input.Length < 2)
            {
                return false;
            }
            else { return true; }
        }

        private async void btnFindWord_Click(object sender, EventArgs e)
        {
            if (ValidInput(txtWord.Text))
            {
                bool wordFound = await GetWordFromDictionaryApi(txtWord.Text);

                if (wordFound)
                {
                    lblCurrentWordSearched.Text = $"{txtWord.Text} was found";
                }
                else
                {
                    lblCurrentWordSearched.Text = $"{txtWord.Text} was not found";
                }
            }
            else
            {
                MessageBox.Show("Word is not valid");
            }
        }

        private List<string> FindAllThatExistInDictionary(List<string[]> permutations, IProgress<string> currentWordProgress)
        {
            List<string> foundList = [];
            int currentPermutationSet = 1;

            foreach (var permutationSet in permutations)
            {
                foreach (var permutation in permutationSet)
                {
                    currentWordProgress.Report($"Set {currentPermutationSet} - {permutation}");

                    bool wordFound = GetWordFromDictionaryApi(permutation).Result;

                    if (wordFound)
                    {
                        foundList.Add(permutation);
                    }
                }
                currentPermutationSet++;
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

        //private void txtPer_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtPer.Text.All(char.IsLetterOrDigit))
        //    {
        //        CheckBox checkBox = new()
        //        {
        //            Name = "wordChar_" + _wordCharIndex,
        //            Text = txtPer.Text.Substring(txtPer.Text.Length - 1),
        //            Location = new System.Drawing.Point(685, _dynamicCheckboxCurrentY),
        //            Font = new System.Drawing.Font("Calibri", 14)
        //        };

        //        checkBox.Click += (sender, e) =>
        //        {
        //            MessageBox.Show(checkBox.Name);
        //        };

        //        this.Controls.Add(checkBox);
        //        _wordCharIndex++;
        //        _dynamicCheckboxCurrentY += 20;
        //    }
        //}
    }
}
