
        public class DelegateMethods
        {
            static int i = 1;
            public delegate string UserCrateCheck(string name, string surname, string password);

            public delegate string UsernameCheckDelegate(string name, string surname);

            public static string UsernameCreate(string name, string surname)
            {
                string username = $"{name.Trim().ToLower()}.{surname.Trim().ToLower()}";
                return username;
            }
            public static string CrateEmail(string name, string surname)
            {

                var email = $"{name.Trim().ToLower()}.{surname.Trim().ToLower()}{i++}@gmail.com";
                return email;
            }



        }
    

