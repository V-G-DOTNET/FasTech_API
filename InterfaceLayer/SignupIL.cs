using System;

namespace InterfaceLayer
{
    public interface SignupIL
    {
        #region Properties

        string FirstName { get; set; }

        string LastName { get; set; }

        string Email { get; set; }

        string Password { get; set; }

        string Role { get; set; }

        #endregion

        #region Functions
        int AddUser();
        //DataSet CheckLogin();
        #endregion
    }
}
