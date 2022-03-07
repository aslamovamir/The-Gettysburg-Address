using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace The_Gettysburg_Address
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // let's store the Gettysburg address in a global variable
        const string address = "Four score and seven years ago our fathers brought forth on this continent a new nation, " +
            "conceived in Liberty, and dedicated to the \nproposition that all men are created equal. \n\nNow we are engaged in" +
            " a great civil war, testing whether that nation or any nation so conceived and so dedicated, can long endure.\nWe" +
            " are met on a great battle-field of that war. We have come to dedicate a portion of that field, as a final resting" +
            " place for those\nwho here gave their lives that that nation might live. It is altogether fitting and proper that we " +
            "should do this. \n\nBut, in a larger sense, we can not dedicate — we can not consecrate — we can not hallow—this ground. " +
            "The brave men, living and\ndead, who struggled here, have consecrated it, far above our poor power to add or detract." +
            " The world will little note, nor long remember\nwhat we say here, but it can never forget what they did here. It is for " +
            "us the living, rather, to be dedicated here to the unfinished work\nwhich they who fought here have thus far so nobly " +
            "advanced. It is rather for us to be here dedicated to the great task remaining before us \n — that from these honored dead" +
            " we take increased devotion to that cause for which they gave the last full measure of devotion—that we \nhere highly" +
            " resolve that these dead shall not have died in vain—that this nation, under God, shall have a new birth of freedom—and" +
            " that\ngovernment of the people, by the people, for the people, shall not perish from the earth.";


        // we will create a struct to store the speech and the number of times the words "we" or "us" have been written in the address
        struct Speech
        {
            public string speech;
            public int count;
        }

        private void Process_BTN_Click(object sender, EventArgs e)
        {
            // we create an instance of the struct speech and initialize the attributes
            Speech gettysburg_speech;
            gettysburg_speech.speech = address;
            gettysburg_speech.count = 0;

            // we will use custom library methods to count the number of times the words "we" and "us" are in the speech
            // first, we get the count of "we"
            gettysburg_speech.count += Regex.Matches(gettysburg_speech.speech, " we ").Count;
        
            // now we add the count of "us"
            gettysburg_speech.count += Regex.Matches(gettysburg_speech.speech, " us ").Count;

            // we update the count label in the GUI
            Count_LBL.Text = gettysburg_speech.count.ToString();
            Refresh();

            // now we replace the substring "we" with "they" in the speech attribute of the struct
            gettysburg_speech.speech = gettysburg_speech.speech.Replace(" we ", " they ");
            //we we replace the substring "us" with "them"
            gettysburg_speech.speech = gettysburg_speech.speech.Replace(" us ", " them ");

            //now we update the text value of the speech in the GUI
            Address_LBL.Text = gettysburg_speech.speech;
            //now we refresh the GUI
            Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // we will display this address in the GUI inside the label "address" when the form loads
            Address_LBL.Text = address;
            // refresh the GUI
            Refresh();
        }
    }
}
