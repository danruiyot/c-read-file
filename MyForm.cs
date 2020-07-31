using System;
using System.IO;
using System.Collections.Generic;  
using Eto.Forms;
using Eto.Drawing;

class MyForm : Eto.Forms.Form
{
	    public static string[] all_words = System.IO.File.ReadAllLines(@"name.txt");
        public static string[] lines = all_words;
        public static int index = 0;

        public static int limit = 1;
        public static int per_page = 1;
        // int viewed = 0;
        public static int lower_limit = 0;

	public MyForm ()
	{
		    ClientSize = new Size(400, 300);

        	var content = new Panel();

			var previousButton = new Button { Text = "Previous" };
			var start = new Button { Text = "Start" };
			var nextButton = new Button { Text = "Next" };
			var Sort = new Button { Text = "Sort" };


			start.Click += (sender, e) =>
			{
                limit = 1;
                per_page = 1;
                lower_limit = 0;

                Control control;
                control = new TextArea { Text = Read_file() };
                // var text_show = new Label { Text = Read_file(false, true) };
				content.Content = new TableLayout(
					null,
					// new Label { Text = string.Format("Control: {0}", control.GetType().Name) },
					new TableRow(control),
					null
				);
			};

			Sort.Click += (sender, e) =>
			{
                Control control;
                control = new TextArea { Text = Read_file(true) };
                // var text_show = new Label { Text = Read_file(false, true) };
				content.Content = new TableLayout(
					null,
					// new Label { Text = string.Format("Control: {0}", control.GetType().Name) },
					new TableRow(control),
					null
				);
			};

			nextButton.Click += (sender, e) =>
			{
                Control control;
                control = new TextArea { Text = Read_file(false, true) };
                // var text_show = new Label { Text = Read_file(false, true) };
				content.Content = new TableLayout(
					null,
					// new Label { Text = string.Format("Control: {0}", control.GetType().Name) },
					new TableRow(control),
					null
				);
			};
			previousButton.Click += (sender, e) =>
			{
                            Control control;
                control = new TextArea { Text = Read_file(false, false, true) };
                // var text_show = new Label { Text = Read_file(false, true) };
				content.Content = new TableLayout(
					null,
					// new Label { Text = string.Format("Control: {0}", control.GetType().Name) },
					new TableRow(control),
					null
				);
			};
			Content = new TableLayout(
				new TableLayout(new TableRow(null, start, previousButton, nextButton, Sort,  null)),
				content
				);
		

	}
	static String Read_file(Boolean sortthis = false, Boolean next = false, Boolean previous = false){
        String words= "";

        
        if(sortthis == true){
        Array.Sort(lines);

        }
        int total = lines.Length;


        if (limit > total) 
        {
            limit = 0;
        }

        if(next == true){
            lower_limit = lower_limit + 1;
           
            limit = limit + 1;
            per_page ++;
        }

        if(previous == true){
            lower_limit = lower_limit - 1;
            limit = limit - 1;
            per_page = per_page -1;
        }
        if (limit < 1)
        {
            limit = 0;
        }
        if (lower_limit < 0)
        {
            lower_limit = 1;
        } 
        if (lower_limit > 0)
        {
            lower_limit = 1;
        }
        // double result = Math.Ceiling(10/15);
              // Console.WriteLine(result);

            for (int i = lower_limit; i < limit; i++) 
            {
                index = i;
                string[] wordz = lines[i].Split(',');
                words += "name : " + wordz[0] + " ";
                words += " " + wordz[1] + " ";
                words += " " + wordz[2] + " ";
				words += System.Environment.NewLine;
                words += "Date Of Admission : " + wordz[3] + " " ;
				words += System.Environment.NewLine;
                words += "Gender : " + wordz[4] + " " ;
                words += System.Environment.NewLine;
                // lines
              Console.WriteLine(lines[i]);
            }

            //   Console.WriteLine(per_page);
            return words;
	}
	void buttonOk_Click(object sender, EventArgs e)
        {
            MessageBox.Show("clicked");
            this.Close(); //all your choice to close it or remove this line
        }


}