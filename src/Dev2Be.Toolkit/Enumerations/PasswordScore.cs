namespace Dev2Be.Toolkit.Enumerations
{
    public enum PasswordScore
    {
        /// <summary>
        /// Aucun mot de passe n'est entré.
        /// </summary>
        Blank = 0,
        /// <summary>
        /// Le mot de passe est trop faible.
        /// </summary>
        VeryWeak = 1,
        /// <summary>
        /// Le mot de passe est faible.
        /// </summary>
        Weak = 2,
        /// <summary>
        /// Le mot de passe est de force moyenne.
        /// </summary>
        Medium = 3,
        /// <summary>
        /// Le mot de passe est fort.
        /// </summary>
        Strong = 4,
        /// <summary>
        /// Le mot de passe est très fort.
        /// </summary>
        VeryStrong = 5
    }
}
