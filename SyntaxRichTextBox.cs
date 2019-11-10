using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace synText_Editor
{
    public partial class SyntaxRichTextBox : System.Windows.Forms.RichTextBox
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern bool ShowCaret(IntPtr hWnd);
        private SyntaxSettings m_settings = new SyntaxSettings();
        private static bool m_bPaint = true;
        private string m_strLine = "";
        private int m_nContentLength = 0;
        private int m_nLineLength = 0;
        private int m_nLineStart = 0;
        private int m_nLineEnd = 0;
        public string m_strKeywords = "";
        private int m_nCurSelection = 0;

        /// <summary>
        /// The settings.
        /// </summary>
        public SyntaxSettings Settings
        {
            get { return m_settings; }
        }

        /// <summary>
        /// WndProc
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == 0x00f)
            {
                if (m_bPaint)
                    base.WndProc(ref m);
                else
                    m.Result = IntPtr.Zero;
            }
            else
                base.WndProc(ref m);
        }
        /// <summary>
        /// OnTextChanged
        /// </summary>
        /// <param name="e"></param>


        protected override void OnTextChanged(EventArgs e)
        {
            HideCaret(this.Handle);
            //Highlight every found word from keyWords.
            // Calculate shit here.
            m_nContentLength = this.TextLength;

            int nCurrentSelectionStart = SelectionStart;
            int nCurrentSelectionLength = SelectionLength;

            m_bPaint = false;

            // Find the start of the current line.
            m_nLineStart = nCurrentSelectionStart;
            while ((m_nLineStart > 0) && (Text[m_nLineStart - 1] != '\n'))
                m_nLineStart--;
            // Find the end of the current line.
            m_nLineEnd = nCurrentSelectionStart;
            while ((m_nLineEnd < Text.Length) && (Text[m_nLineEnd] != '\n'))
                m_nLineEnd++;
            // Calculate the length of the line.
            m_nLineLength = m_nLineEnd - m_nLineStart;
            // Get the current line.
            m_strLine = Text.Substring(m_nLineStart, m_nLineLength);

            // Process this line.
            ProcessLine();

            m_bPaint = true;
            ShowCaret(this.Handle);
        }

        /// <summary>
        /// Process a line.
        /// </summary>
        private void ProcessLine()
        {

            // Save the position and make the whole line black
            int nPosition = SelectionStart;
            SelectionStart = m_nLineStart;
            SelectionLength = m_nLineLength;
            SelectionColor = Color.White;

            // Process the keywords
            ProcessRegex(m_strKeywords, Settings.KeywordColor, Settings.RgxKeywords);
            // Process numbers
            if (Settings.EnableIntegers)
                ProcessRegex("\\b(?:[0-9]*\\.)?[0-9]+\\b", Settings.IntegerColor,RegexOptions.None);
            // Process strings
            if (Settings.EnableStrings)
            {
                ProcessRegex("\"[^\"\\\\\\r\\n]*(?:\\\\.[^\"\\\\\\r\\n]*)*\"", Settings.StringColor, RegexOptions.None);
                ProcessRegex("'[^\'\\\\\\r\\n]*(?:\\\\.[^\'\\\\\\r\\n]*)*'", Settings.StringColor, RegexOptions.None);
            }
            // Process comments
            if (Settings.EnableComments && !string.IsNullOrEmpty(Settings.Comment))
            {
                ProcessRegex(Settings.Comment + ".*$", Settings.CommentColor, RegexOptions.None);
            }
            if (Settings.EnableComments && !string.IsNullOrEmpty(Settings.LongComment))
            {
                ProcessRegex(Settings.LongComment, Settings.CommentColor, RegexOptions.IgnoreCase);
            }

            SelectionStart = nPosition;
            SelectionLength = 0;
            SelectionColor = Color.Black;

            m_nCurSelection = nPosition;
        }
        /// <summary>
        /// Process a regular expression.
        /// </summary>
        /// <param name="strRegex">The regular expression.</param>
        /// <param name="color">The color.</param>
        private void ProcessRegex(string strRegex, Color color, RegexOptions rgxOp = RegexOptions.None)
        {
            Regex rex = new Regex(strRegex, rgxOp );
            MatchCollection mc = rex.Matches(Text);
            int StartCursorPosition = SelectionStart;
            foreach (Match m in mc)
            {
                int startIndex = m.Index;
                int StopIndex = m.Length;
                Select(startIndex, StopIndex);
                SelectionColor = color;
                SelectionStart = StartCursorPosition;
            }
        }
        /// <summary>
        /// Compiles the keywords as a regular expression.
        /// </summary>
        public void CompileKeywords()
        {
            for (int i = 0; i < Settings.Keywords.Count; i++)
            {
                string strKeyword = Settings.Keywords[i];

                if (i == Settings.Keywords.Count - 1)
                    m_strKeywords += "\\b" + strKeyword + "\\b";
                else
                    m_strKeywords += "\\b" + strKeyword + "\\b|";
            }
        }

        public void ProcessAllLines()
        {
            m_bPaint = false;

            int nStartPos = 0;
            int i = 0;
            int nOriginalPos = SelectionStart;
            while (i < Lines.Length)
            {
                m_strLine = Lines[i];
                m_nLineStart = nStartPos;
                m_nLineEnd = m_nLineStart + m_strLine.Length;

                ProcessLine();
                i++;

                nStartPos += m_strLine.Length + 1;
            }

            m_bPaint = true;
        }
        public int Bul(string kelime, Color renk)
        {
            Select(0, TextLength);
            SelectionBackColor = this.BackColor;
            int adet = 0;
            if (!string.IsNullOrEmpty(kelime))
            {
                int s_start = SelectionStart, startIndex = 0, index;

                while ((index = Text.IndexOf(kelime, startIndex)) != -1)
                {
                    Select(index, kelime.Length);
                    SelectionBackColor = renk;
                    startIndex = index + kelime.Length;
                    adet++;
                }

                SelectionStart = s_start;
                SelectionLength = 0;
                SelectionColor = Color.Black;
            }
            return adet;
        }

        public int Degistir(string kelime, string yeniKelime, Color renk)
        {
            Select(0, TextLength);
            SelectionBackColor = this.BackColor;
            int adet = 0;
            if (!string.IsNullOrEmpty(kelime))
            {
                int s_start = SelectionStart, startIndex = 0, index;

                while ((index = Text.IndexOf(kelime, startIndex)) != -1)
                {
                    Select(index, kelime.Length);
                    SelectionBackColor = renk;
                    Select(index, kelime.Length);
                    startIndex = index + kelime.Length;
                    SelectedText = yeniKelime;
                    adet++;
                    //break; //tek tek değiştirmek için
                }

                SelectionStart = s_start;
                SelectionLength = 0;
                SelectionColor = Color.Black;
            }
            return adet;
        }
    }

    /// <summary>
    /// Class to store syntax objects in.
    /// </summary>
    public class SyntaxList
    {
        public List<string> m_rgList = new List<string>();
        public Color m_color = new Color();
    }

    /// <summary>
    /// Settings for the keywords and colors.
    /// </summary>
    public class SyntaxSettings
    {
        SyntaxList m_rgKeywords = new SyntaxList();
        string m_strComment = "";
        string m_strLongComment = "";
        Color m_colorComment = Color.Green;
        Color m_colorString = Color.Gray;
        Color m_colorInteger = Color.Red;
        bool m_bEnableComments = false;
        bool m_bEnableIntegers = false;
        bool m_bEnableStrings = false;
        RegexOptions m_rgxKeywords = RegexOptions.None;

        #region Properties
        public RegexOptions RgxKeywords
        {
            get { return m_rgxKeywords; }
            set { m_rgxKeywords = value; }
        }
        /// <summary>
        /// A list containing all keywords.
        /// </summary>
        public List<string> Keywords
        {
            get { return m_rgKeywords.m_rgList; }
            set { m_rgKeywords.m_rgList = value; }
        }
        /// <summary>
        /// The color of keywords.
        /// </summary>
        public Color KeywordColor
        {
            get { return m_rgKeywords.m_color; }
            set { m_rgKeywords.m_color = value; }
        }

        /// <summary>
        /// A string containing the comment identifier.
        /// </summary>
        public string Comment
        {
            get { return m_strComment; }
            set { m_strComment = value; }
        }
        /// <summary>
        /// A string containing the comment identifier.
        /// </summary>
        public string LongComment
        {
            get { return m_strLongComment; }
            set { m_strLongComment = value; }
        }
        /// <summary>
        /// The color of comments.
        /// </summary>
        public Color CommentColor
        {
            get { return m_colorComment; }
            set { m_colorComment = value; }
        }

        /// <summary>
        /// Enables processing of comments if set to true.
        /// </summary>
        public bool EnableComments
        {
            get { return m_bEnableComments; }
            set { m_bEnableComments = value; }
        }
        /// <summary>
        /// Enables processing of integers if set to true.
        /// </summary>
        public bool EnableIntegers
        {
            get { return m_bEnableIntegers; }
            set { m_bEnableIntegers = value; }
        }
        /// <summary>
        /// Enables processing of strings if set to true.
        /// </summary>
        public bool EnableStrings
        {
            get { return m_bEnableStrings; }
            set { m_bEnableStrings = value; }
        }
        /// <summary>
        /// The color of strings.
        /// </summary>
        public Color StringColor
        {
            get { return m_colorString; }
            set { m_colorString = value; }
        }
        /// <summary>
        /// The color of integers.
        /// </summary>
        public Color IntegerColor
        {
            get { return m_colorInteger; }
            set { m_colorInteger = value; }
        }
        #endregion
    }
}
