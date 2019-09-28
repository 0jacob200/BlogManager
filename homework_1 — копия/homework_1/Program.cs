using System;
using System.Collections.Generic;

namespace homework_1
{

    class BlogPost
    {
        public BlogPost(int id, string name, string text, DateTime dateP)
        {
            Id = id;
            NamePost = name;
            TextPost = text;
            DatePublished = dateP;

        }

        public DateTime DatePublished { get; }
        public int Id { get; }
        public string NamePost { get; set; }
        public string TextPost { get; set; }

    }

    class BlogManager
    {
        private List<BlogPost> _listBlog;

        public BlogManager()
        {
            List<BlogPost> listOfBlog = new List<BlogPost>();
            _listBlog = listOfBlog;
        }

        public void AddNewPost(string nameP, string textP, DateTime datePubP)
        {
            int idP = _listBlog.Count;
            BlogPost post = new BlogPost(idP, nameP, textP, datePubP);
            _listBlog.Add(post);

        }

        public bool RemoveThePost(int id)
        {
            bool flagOfRemove = true;
            try
            {
                _listBlog.RemoveAt(--id);
            }
            catch
            {
                flagOfRemove = false;
            }
            return flagOfRemove;

        }

        public Dictionary<string, List<string> > ShowPosts()
        {
            Dictionary< string, List<string> > dictPost = new Dictionary<string, List<string> >();
            int counter = 0;
            foreach (BlogPost posteEl in _listBlog)
            {
                List<string> post = new List<string> {posteEl.NamePost, posteEl.TextPost,
                    Convert.ToString(posteEl.DatePublished.ToUniversalTime()) };
                dictPost.Add(Convert.ToString(++counter), post);
            }
            return dictPost;

        }

        public void ChangeThePost(int id, string newNameP, string newTextP)
        {
            id--;
            if (newNameP != "")
            {
                _listBlog[id].NamePost = newNameP;
            }
            if (newTextP!= "")
            {
                _listBlog[id].TextPost = newTextP;
            }

        }

        public bool EmptyBlogOrComparising( int numToCompare = 0)
        {
            if ( (_listBlog.Count == 0) || ((0 < numToCompare) && (numToCompare <= _listBlog.Count)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    class Program
    {
        public const string SEPARATOR = "_______________________________________";
        public const string WRONGINPUT = "Wrong input! Try again.";
        public const string CONTINUE = "Press any button to continue";
        public const string EMPTYBLOG = "There is no post in your blog. You can add someone in menu";

        public static void AddPostProgram(BlogManager Blog)
        {
            Console.WriteLine("Add name of new post: ");
            string namePost = Console.ReadLine();
            Console.WriteLine("Here is the text of your post:");
            string textPost = Console.ReadLine();
            Blog.AddNewPost(namePost, textPost, DateTime.Now);
            Console.WriteLine(SEPARATOR + "\nThe post has  been added");
            Console.Write(SEPARATOR + "\n" +
                CONTINUE);

        }

        public static void RemovePost(BlogManager Blog)
        {
            if (Blog.EmptyBlogOrComparising() == true)
            {
                Console.WriteLine(EMPTYBLOG);
            }
            else
            {
                Console.WriteLine("Enter ID of the post:");
                int idToRemove = 0;
                try
                {
                    idToRemove = Convert.ToInt16(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine(WRONGINPUT);
                    return;
                }
                bool successfulOperationRemove = Blog.RemoveThePost(idToRemove);
                if (successfulOperationRemove == true)
                {
                    Console.WriteLine(SEPARATOR + "\nThe post has  been removed");
                }
                else
                {
                    Console.WriteLine("There is no such id");
                }
            }
            Console.WriteLine(SEPARATOR + "\n" + CONTINUE);

        }

        public static void ShowAllPosts(BlogManager Blog)
        {
            Dictionary<string, List<string>> postsToShow = Blog.ShowPosts();
            Console.WriteLine("Here is all your posts\n" +
                SEPARATOR + "\n");
            if (postsToShow.Count == 0)
            {
                Console.WriteLine(EMPTYBLOG);
            }
            foreach (KeyValuePair<string, List<string>> keyvaluePost in postsToShow)
            {
                Console.WriteLine("Id of the post: {0}\n" +
                    "It's name: {1}\n" +
                    "The body: {2}\n" +
                    "The time of publishing: {3}\n",
                    keyvaluePost.Key, keyvaluePost.Value[0], keyvaluePost.Value[1], keyvaluePost.Value[2] );
            }
            Console.WriteLine(SEPARATOR + "\n" +
                CONTINUE);
        }

        public static void ChangeThePost(BlogManager Blog)
        {
            if (Blog.EmptyBlogOrComparising() == true)
            {
                Console.WriteLine(EMPTYBLOG);
            }
            else
            {
                Console.WriteLine("To change the post enter its Id: ");
                int idPostToChange = 0;
                try
                {
                    idPostToChange = Convert.ToInt16(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine(WRONGINPUT);
                    return;
                }
                if (Blog.EmptyBlogOrComparising(idPostToChange) == true)
                {
                    Console.WriteLine(SEPARATOR + "\nIf you don't want to change name or text of the post, just press ENTER\n" +
                    SEPARATOR + "\nNew Name: ");
                    string newName = Console.ReadLine();
                    Console.WriteLine("New Text: ");
                    string newText = Console.ReadLine();
                    Blog.ChangeThePost(idPostToChange, newName, newText);
                    Console.WriteLine(SEPARATOR + "\nThe post has being changed");
                }
                else
                {
                    Console.WriteLine(WRONGINPUT);
                    return;
                }
            }
            Console.WriteLine(SEPARATOR + "\n" +
                CONTINUE);

        }

        static void Main(string[] args)
        {
            bool flagToContinue = true;
            BlogManager Blog1 = new BlogManager();
            do
            {
                Console.Clear();
                Console.WriteLine("Hello! This is Blog\n" + SEPARATOR +
                    "\n1. Add a new post in your Blog\n" +
                    "2. Show all your post\n" +
                    "3. Change post\n" +
                    "4. Remove one of your post\n" +
                    "5. Exit\n" + SEPARATOR +
                    "\nEnter number of operation: ");
                int operationNumber = 6;
                try
                {
                    operationNumber = Convert.ToInt16(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine(WRONGINPUT);
                    Console.ReadKey();
                    continue;
                }
                catch (OverflowException)
                {
                    Console.WriteLine(WRONGINPUT);
                    Console.ReadKey();
                    continue;
                }
                Console.Clear();
                switch (operationNumber)
                {
                    case 1:
                        AddPostProgram(Blog1);
                        break;
                    case 2:
                        ShowAllPosts(Blog1);
                        break;
                    case 3:
                        ChangeThePost(Blog1);
                        break;
                    case 4:
                        RemovePost(Blog1);
                        break;
                    case 5:
                        flagToContinue = false;
                        Console.WriteLine("GoodBye!");
                        break;
                    default:
                        Console.WriteLine(WRONGINPUT);
                        break;
                }
                Console.ReadKey();
            }
            while (flagToContinue == true);
            Console.Clear();

        }

    }

}
