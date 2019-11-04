/*Sarah Kollins
 *iOS iPhone 8
 *Using synchronous
 * What works: Everythings works. 
 * What doesn't work: Nothing
 * Assumption: User has to specify a word length before hitting "Find". If they don't, an error occurs.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using Xamarin.Forms;

namespace Project2
{
    public class MainPage: ContentPage
    {
        List<string> wordList = new List<string>();
        EnglishWords englishWords;
        Entry wordEntry;
        Entry letterNumberEntry;
        ScrollView scrollView;
        StackLayout bottomLayout;
        Label wordsLabel = new Label { Text = "" , FontSize=17, HorizontalOptions = LayoutOptions.Center};
        CheckBox checkBox;
        StackLayout titleLayout = new StackLayout();
        Button findButton = new Button { Text = "Find", HorizontalOptions = LayoutOptions.End, Margin = new Thickness(0, 0, 0, 0) };
        Button clearButton = new Button { Text = "Clear", HorizontalOptions = LayoutOptions.End, Margin = new Thickness(20, 0, 0, 0) };

        //Constructor
        public MainPage()
        {
           
           englishWords = new EnglishWords();
            wordList = englishWords.getWordList();

            this.Padding = new Thickness(5,21,5,2);
            //Creation of the stacklayouts
            StackLayout stackLayout = new StackLayout();
            StackLayout topLayout = new StackLayout { Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(0, 0, 10, 20)};
            StackLayout middleLayout = new StackLayout { Orientation = StackOrientation.Horizontal };
           bottomLayout  = new StackLayout();

            //Formatting the title label
            Label title = new Label { Text = "Welcome to WordFinder", Margin = new Thickness(0,20,0,10), HorizontalOptions = LayoutOptions.Center
            , FontSize = 30};
            titleLayout.Children.Add(title);
            titleLayout.BackgroundColor = Color.PowderBlue;
           
            //Formatting the entry of letters
            wordEntry = new Entry { Text = ""};
            
            wordEntry.WidthRequest = 200;
            Label dupLabel = new Label { Text = "Duplicate Letters?" };
            checkBox = new CheckBox();
            checkBox.Color = Color.PowderBlue;
           
            topLayout.Children.Add(wordEntry);
            topLayout.Children.Add(dupLabel);
            topLayout.Children.Add(checkBox);

            //Formatting the word length entry
            Label wordLengthLabel = new Label { Text = "Enter in word length:"};
            letterNumberEntry = new Entry ();
            letterNumberEntry.WidthRequest = 40;
            middleLayout.Children.Add(wordLengthLabel);
            middleLayout.Children.Add(letterNumberEntry);
         
            //Formatting the buttons
            findButton.FontSize = 20;
            findButton.TextColor = Color.White;
            findButton.BackgroundColor = Color.PowderBlue;
            findButton.Clicked += OnClick;
            clearButton.FontSize = 20;
            clearButton.TextColor = Color.White;
            clearButton.BackgroundColor = Color.PowderBlue;
            clearButton.Clicked += OnClick;


            scrollView = new ScrollView();
            scrollView.Content = bottomLayout;
           
            //Adding all content to main stack layout
            stackLayout.Children.Add(titleLayout);
            stackLayout.Children.Add(clearButton);
            stackLayout.Children.Add(topLayout);
            stackLayout.Children.Add(middleLayout);
            stackLayout.Children.Add(findButton);
            stackLayout.Children.Add(scrollView);
            this.Content = stackLayout;
          
        }

        //Event when "Clear" or "Find" is clicked
        //Will either clear the page or search for available words
        private void OnClick(object sender, EventArgs e)
        { 
            Button button = (Button)sender;
            if (button.Text == "Find")
            {
                if(wordsLabel.Text != "")
                {
                    wordsLabel.Text = "";
                    wordList.Clear();
                }
                if (checkBox.IsChecked == false) {
                    wordList = englishWords.AvailableWords(wordEntry.Text, Int32.Parse(letterNumberEntry.Text));
                    foreach (String word in wordList)
                    {
                        wordsLabel.Text += "\n" + word;

                    }
                }
                //For duplicate letters
                else
                {
                    wordList = englishWords.AvailableWordsDuplicate(wordEntry.Text, Int32.Parse(letterNumberEntry.Text));
                    foreach (String word in wordList)
                    {
                        wordsLabel.Text += "\n" + word;

                    }
                }
            }
            //For clear button
            else
            {
                wordEntry.Text = "";
                letterNumberEntry.Text = "";
                wordList.Clear();
                wordsLabel.Text = "";
            }
            bottomLayout.Children.Add(wordsLabel);
        }

    }//End Class
}//End namespace
