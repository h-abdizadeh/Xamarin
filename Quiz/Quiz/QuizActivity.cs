using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Quiz
{
    [Activity(Label = "QuizActivity")]
    public class QuizActivity : Activity
    {
        //string[] quizBtn = new string[4];
        string answer;
        int i = 0;//question index

        ImageView imgMain;
        Button btn1, btn2, btn3, btn4, btnNxt;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.quiz_layout);

            imgMain = FindViewById<ImageView>(Resource.Id.imageView1);
            btn1 = FindViewById<Button>(Resource.Id.button1);
            btn2 = FindViewById<Button>(Resource.Id.button2);
            btn3 = FindViewById<Button>(Resource.Id.button3);
            btn4 = FindViewById<Button>(Resource.Id.button4);
            btnNxt = FindViewById<Button>(Resource.Id.button5);

            //load xml
            XmlDocument xml = new XmlDocument();
            StreamReader sr = 
                new StreamReader(Assets.Open("Question.xml"));
            xml.Load(sr);


            //load question
            XmlElement xmlTag =
                (XmlElement)xml.GetElementsByTagName("a1")[0];
            btn1.Text = xmlTag.InnerText;

            xmlTag = (XmlElement)xml.GetElementsByTagName("a2")[0];
            btn2.Text = xmlTag.InnerText;

            xmlTag = (XmlElement)xml.GetElementsByTagName("a3")[0];
            btn3.Text = xmlTag.InnerText;

            xmlTag = (XmlElement)xml.GetElementsByTagName("a4")[0];
            btn4.Text = xmlTag.InnerText;


            //load answer
            xmlTag = (XmlElement)xml.GetElementsByTagName("answer")[0];
            answer = xmlTag.InnerText;



            //load image
            //imgMain.SetImageResource(Resource.Drawable.tesla);
            xmlTag = (XmlElement)xml.GetElementsByTagName("image")[0];
            string imgName = xmlTag.InnerText;
            int imgId = 
                (int)typeof(Resource.Drawable).GetField(imgName).GetValue(null);

            imgMain.SetImageResource(imgId);




            btn1.Click += delegate
            {
                CheckAnswer(btn1.Text);
            };

            btn2.Click += delegate
            {
                CheckAnswer(btn2.Text);
            };

            btn3.Click += delegate
            {
                CheckAnswer(btn3.Text);
            };

            btn4.Click += delegate
            {
                CheckAnswer(btn4.Text);
            };

            btnNxt.Click += delegate
            {
                if (i<4)
                {
                    i++;

                xmlTag =
               (XmlElement)xml.GetElementsByTagName("a1")[i];
                btn1.Text = xmlTag.InnerText;

                xmlTag = (XmlElement)xml.GetElementsByTagName("a2")[i];
                btn2.Text = xmlTag.InnerText;

                xmlTag = (XmlElement)xml.GetElementsByTagName("a3")[i];
                btn3.Text = xmlTag.InnerText;

                xmlTag = (XmlElement)xml.GetElementsByTagName("a4")[i];
                btn4.Text = xmlTag.InnerText;


                //load answer
                xmlTag = (XmlElement)xml.GetElementsByTagName("answer")[i];
                answer = xmlTag.InnerText;

                //load image
                //imgMain.SetImageResource(Resource.Drawable.tesla);
                xmlTag = (XmlElement)xml.GetElementsByTagName("image")[i];
                 imgName = xmlTag.InnerText;
                 imgId =
                    (int)typeof(Resource.Drawable).GetField(imgName).GetValue(null);

                imgMain.SetImageResource(imgId);

                btnNxt.Visibility = ViewStates.Gone;
                }
                else
                {
                    imgMain.Visibility = ViewStates.Gone;
                    btn1.Visibility = ViewStates.Gone;
                    btn2.Visibility = ViewStates.Gone;
                    btn3.Visibility = ViewStates.Gone;
                    btn4.Visibility = ViewStates.Gone;

                    btnNxt.Text = "پایان";
                }
            };
        }

        void CheckAnswer(string userAnswer)
        {
            if (answer==userAnswer)
            {
                Toast.MakeText(this, "درست", ToastLength.Short).Show();
                btnNxt.Text = "ادامه";
                btnNxt.Visibility = ViewStates.Visible;
            }
            else
            {
                Toast.MakeText(this, "نادرست", ToastLength.Short).Show();
            }
        }
    }
}