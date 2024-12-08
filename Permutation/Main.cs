
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
        public frmPerm()
        {
            InitializeComponent();
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

            List<IEnumerable<string>> permutationsList;

            if (!string.IsNullOrEmpty(txtLetterPosition.Text) && !string.IsNullOrEmpty(txtSubtitutionLetters.Text))
            {
                permutationsList = await Task.Run(() => GetPermutationsWithSubstitutions());

                if (chkViewAllPermutations.Checked)
                {
                    foreach (var permutationSet in permutationsList)
                    {
                        AddItemsToListBox(permutationSet, lstAllPermutations);
                    }
                }
            }
            else
            {
                var singleWordPermutations = await Task.Run(() => PermutationGenerator.GetAllUsingOldAlgorithm(txtWord.Text.ToString()));

                if (chkViewAllPermutations.Checked)
                {
                    AddItemsToListBox(singleWordPermutations, lstAllPermutations);
                }
                   
                permutationsList = new() { singleWordPermutations };
            }

            var foundList = await Task.Run(() => FindAllThatExistInDictionary(permutationsList, currentWordProgress));

            lblCurrentWordSearched.Text = "Search Complete";

            foreach (var word in foundList)
            {
                lstDictionaryWords.Items.Add(word);
            }

            stopWatch.Stop();
            lblRunTime.Text = stopWatch.Elapsed.ToString();
        }

        private List<IEnumerable<string>> GetPermutationsWithSubstitutions()
        {
            if (!int.TryParse(txtLetterPosition.Text, out var letterPos)) { throw new Exception("Letter Position is not valid"); }
            if (letterPos > txtWord.Text.Length) { throw new Exception("Letter position is out of bounds"); }

            var permutationsList = new List<IEnumerable<string>>();
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
                var wordPermutations = PermutationGenerator.GetAllUsingOldAlgorithm(word);
                permutationsList.Add(wordPermutations);
            }

            return permutationsList;
        }

        private void AddItemsToListBox(IEnumerable<string> items, ListBox listbox)
        {
            foreach (var item in items)
            {
                if (!string.IsNullOrEmpty(item))
                    listbox.Items.Add(item);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstAllPermutations.Items.Clear();
            lstDictionaryWords.Items.Clear();
            txtWord.Clear();
            lblCurrentWordSearched.Text = "-------------";
            txtLetterPosition.Text = "";
            txtSubtitutionLetters.Text = "";
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
                bool wordFound = await DictionaryApi.WordExists(txtWord.Text);

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

        private List<string> FindAllThatExistInDictionary(List<IEnumerable<string>> permutations, IProgress<string> currentWordProgress)
        {
            List<string> foundList = [];
            int currentPermutationSet = 1;

            foreach (var permutationSet in permutations)
            {
                foreach (var permutation in permutationSet)
                {
                    currentWordProgress.Report($"Set {currentPermutationSet} - {permutation}");

                    bool wordFound = DictionaryApi.WordExists(permutation).Result;

                    if (wordFound)
                    {
                        foundList.Add(permutation);
                    }
                }
                currentPermutationSet++;
            }

            return foundList;
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
