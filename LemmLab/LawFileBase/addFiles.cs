using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LemmLab;
using FileBase;
using System.IO;

namespace LawFileBase
{
	public partial class addFiles : Form
	{
		private class lemmWordCount
		{
			public int count;
			public string origin;
			public lemmWordCount(int a, string b)
			{
				count = a;
				origin = b;
			}
		}
		LemmManager LM = new LemmManager();
		FileBaseManager FBM = new FileBaseManager();
		OpenFileDialog FileOpen = new OpenFileDialog();

		Boolean chooseWords = false;
		Dictionary<string, lemmWordCount> sortedLemms = new Dictionary<string, lemmWordCount>();
		Dictionary<string, CheckBox> checks = new Dictionary<string, CheckBox>();
		public addFiles()
		{
			InitializeComponent();
			FBM.SetLocation(@"C:\Users\User\Documents\Visual Studio 2017\Projects\LemmLab\serchProto\bin\Debug\FB");
		}
		public addFiles(string location)
		{
			InitializeComponent();
			FBM.SetLocation(location);
		}
		private void button1_Click(object sender, EventArgs e)
		{
			if (FileOpen.ShowDialog(this) == DialogResult.OK)
			{
				var reader = new StreamReader(FileOpen.OpenFile(), Encoding.Default);
				var pageText = reader.ReadToEnd();
				sortedLemms = new Dictionary<string, lemmWordCount>();
				foreach (var word in LM.ToWordsHTML(pageText))
				{
					if (LM.ToLemm(word) != "")
					{
						if (!sortedLemms.ContainsKey(LM.ToLemm(word)))
						{
							sortedLemms.Add(LM.ToLemm(word), new lemmWordCount(1, word));
						}
						else
						{
							sortedLemms[LM.ToLemm(word)].count++;
						}
					}
				}
				flowLayoutPanel1.Controls.Clear();
				flowLayoutPanel1.Controls.Add(button3);
				button2.Enabled = true;
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			var reader = new StreamReader(FileOpen.OpenFile(), Encoding.Default);
			var pageText = reader.ReadToEnd();
			try
			{
				FBM.WriteToFile(FileOpen.SafeFileName, pageText);
			}
			catch (Exception) { }
			if (chooseWords)
			{
				HashSet<string> choosedLemms = new HashSet<string>();
				foreach (var but in checks)
					if (but.Value.Checked) choosedLemms.Add(but.Key);
				string[] allWords = LM.ToWordsHTML(pageText);
				int wordsCount = (from a in allWords where choosedLemms.Contains(LM.ToLemm(a)) select a).Count();
				FBM.AddToListOfFiles(FileOpen.SafeFileName, wordsCount);
				var dic = FBM.GetDictionaryInDictionaryForm();
				var maxId = dic.Count != 0 ? (from a in dic select a.Value).Max() + 1 : 0;
				foreach (var a in choosedLemms)
				{
					if (!dic.ContainsKey(a))
						dic.Add(a, maxId++);
					var amount = (from b in allWords where a == LM.ToLemm(b) select b).Count();
					FBM.AddFileToWord(dic[a], FileOpen.SafeFileName.Replace(".htm", ""), amount);
				}
				FBM.SetDictionary(dic);
			}
			else
			{
				HashSet<string> choosedLemms = new HashSet<string>();
				foreach (var but in sortedLemms)
					if (LM.IsWorthy(but.Value.origin)) choosedLemms.Add(but.Key);
				string[] allWords = LM.ToWordsHTML(pageText);
				int wordsCount = (from a in allWords where choosedLemms.Contains(LM.ToLemm(a)) select a).Count();
				FBM.AddToListOfFiles(FileOpen.SafeFileName, wordsCount);
				var dic = FBM.GetDictionaryInDictionaryForm();
				var maxId = dic.Count != 0 ? (from a in dic select a.Value).Max() + 1 : 0;
				foreach (var a in choosedLemms)
				{
					if (!dic.ContainsKey(a))
						dic.Add(a, maxId++);
					var amount = (from b in allWords where a == LM.ToLemm(b) select b).Count();
					FBM.AddFileToWord(dic[a], FileOpen.SafeFileName.Replace(".htm", ""), amount);
				}
				FBM.SetDictionary(dic);
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			chooseWords = true;
			checks = new Dictionary<string, CheckBox>();
			flowLayoutPanel1.Controls.Remove(button3);
			foreach (var word in sortedLemms.OrderBy((x)=>x.Value.count+x.Key[0]/1000))
			{
				var oneBut = new CheckBox();
				oneBut.Text = word.Value.origin + " (" + word.Value.count + ")";
				oneBut.Checked = LM.IsWorthy(word.Value.origin);
				flowLayoutPanel1.Controls.Add(oneBut);
				checks.Add(word.Key, oneBut);
			}
		}
	}
}
