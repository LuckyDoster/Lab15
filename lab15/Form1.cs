using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace lab15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = textBox1.Text.Trim();
            if (text.Length == 0)
            {
                res1_error.Text = "Empty value provided";
                return;
            }

            try
            {
                double x = Convert.ToDouble(text);
                var res = x - Math.Pow(x, 3) / 3.0 + Math.Pow(x, 5) / 5.0;

                res1.Text = res.ToString();
                res1_error.Text = string.Empty;
            }
            catch (FormatException)
            {
                res1_error.Text = "Invalid number provided";
            }
            catch (OverflowException)
            {
                res1_error.Text = "Number too large";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var a_text = textBox2.Text.Trim();
            var d_text = textBox3.Text.Trim();
            var n_text = textBox4.Text.Trim();
            var err_msg = string.Empty;
            if (a_text.Length == 0)
            {
                err_msg += "A";
            }
            if (d_text.Length == 0)
            {
                if (err_msg.Length != 0)
                {
                    err_msg += ", ";
                }
                err_msg += "D";
            }
            if (n_text.Length == 0)
            {
                if (err_msg.Length != 0)
                {
                    err_msg += ", ";
                }
                err_msg += "N";
            }

            if (err_msg.Length != 0)
            {
                res2_error.Text = "Empty value provided for vars: " + err_msg;
                return;
            }

            try
            {
                var a = Convert.ToInt32(a_text);
                var d = Convert.ToInt32(d_text);
                var n = Convert.ToInt32(n_text);
                var res = ((2 * a + d * (n - 1)) / 2) * n;

                res2.Text = res.ToString();
                res2_error.Text = string.Empty;
            }
            catch (FormatException)
            {
                res2_error.Text = "Invalid number provided";
            }
            catch (OverflowException)
            {
                res2_error.Text = "Number too large";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var a_text = textBox7.Text.Trim();
            var b_text = textBox6.Text.Trim();
            var c_text = textBox5.Text.Trim();
            var err_msg = string.Empty;
            if (a_text.Length == 0)
            {
                err_msg += "A";
            }
            if (b_text.Length == 0)
            {
                if (err_msg.Length != 0)
                {
                    err_msg += ", ";
                }
                err_msg += "B";
            }
            if (c_text.Length == 0)
            {
                if (err_msg.Length != 0)
                {
                    err_msg += ", ";
                }
                err_msg += "C";
            }

            if (err_msg.Length != 0)
            {
                res3_error.Text = "Empty value provided for vars: " + err_msg;
                return;
            }

            try
            {
                var a = Convert.ToInt32(a_text);
                var b = Convert.ToInt32(b_text);
                var c = Convert.ToInt32(c_text);
                var res = a == b && b == c;

                res3.Text = res.ToString().ToLower();
                res3_error.Text = string.Empty;
            }
            catch (FormatException)
            {
                res3_error.Text = "Invalid number provided";
            }
            catch (OverflowException)
            {
                res3_error.Text = "Number too large";
            }
        }

        enum AccessLevel
        {
            Root,
            Admin,
            User,
            None
        }


        private void button4_Click(object sender, EventArgs e)
        {
            var pass = textBox8.Text.Trim();

            var access = pass switch
            {
                "9583" => AccessLevel.Root,
                "1747" => AccessLevel.Root,
                "3331" => AccessLevel.Admin,
                "7922" => AccessLevel.Admin,
                "9455" => AccessLevel.User,
                "8997" => AccessLevel.User,
                _ => AccessLevel.None,
            };

            switch (access)
            {
                case AccessLevel.Root: res4.Text = "A, B, C"; break;
                case AccessLevel.Admin: res4.Text = "B, C"; break;
                case AccessLevel.User: res4.Text = "C"; break;
                case AccessLevel.None: res4.Text = "None"; break;
            };

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var n_text = textBox9.Text.Trim();

            if (n_text.Length == 0)
            {
                res5_error.Text = "Empty value provided";
                return;
            }

            try
            {
                var n = Convert.ToInt32(n_text);
                if (n > 9)
                {
                    res5_error.Text = "Non-natural value provided";
                    return;
                }

                var list = new List<int[]>();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        for (int k = 0; k < n; k++)
                        {
                            if (Math.Pow(i, 2) + Math.Pow(j, 2) == Math.Pow(k, 2))
                            {
                                list.Add([i, j, k]);
                            }
                        }
                    }
                }

                var res = new StringBuilder();
                foreach (int[] p in list)
                {
                    if (res.Length != 0)
                    {
                        res.Append(", ");
                    }
                    res.Append($"({p[0]}, {p[1]}, {p[2]})");
                }

                res5.Text = res.ToString();
                res5_error.Text = string.Empty;
            }
            catch (FormatException)
            {
                res5_error.Text = "Invalid number provided";
            }
            catch (OverflowException)
            {
                res5_error.Text = "Number too large";
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            var list_text = textBox10.Text.Trim().Split(',');
            var min_text = textBox11.Text.Trim();
            var max_text = textBox12.Text.Trim();
            if (min_text.Length == 0)
            {
                res6_error.Text = "Empty min value provided";
                return;
            }
            if (max_text.Length == 0)
            {
                res6_error.Text = "Empty max value provided";
                return;
            }
            var nums = new List<int>();
            foreach (string i in list_text)
            {
                try
                {
                    nums.Add(Convert.ToInt32(i));
                }
                catch (Exception)
                {
                    res6_error.Text = "Invalid number list provided";
                    return;
                }
            }
            try
            {
                var min = Convert.ToInt32(min_text);
                var max = Convert.ToInt32(max_text);
                var sum = 0;
                foreach (int i in nums)
                {
                    if (i >= min || i <= max)
                    {
                        sum += i;
                    }
                }

                res6.Text = sum.ToString();
                res6_error.Text = string.Empty;
            }
            catch (FormatException)
            {
                res6_error.Text = "Invalid number provided";
            }
            catch (OverflowException)
            {
                res6_error.Text = "Number too large";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var text = textBox15.Text;
            var len = text.IndexOf(':');
            if (len == -1)
            {
                res7.Text = string.Empty;
                res7_error.Text = "Colon not found";
                return;
            }
            res7.Text = len.ToString();
        }
    }
}
