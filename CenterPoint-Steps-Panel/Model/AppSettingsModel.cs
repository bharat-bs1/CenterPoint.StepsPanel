namespace Tutkoo.mintyfusion.CenterPoint.StepsPanel.Model
{
    #region Enum
    public enum ConnectionType
    {
        SqlServer = 0,
    }
    #endregion Enum

    #region Class
    public class AppSettingsModel
    {
        #region Properties
        public ConnectionStrings[] Keys { get; set; }
        #endregion Properties

        #region Public Methods
        public string GetKey(ConnectionType type)
        {
            string key = string.Empty;

            switch (type)
            {
                case ConnectionType.SqlServer:
                    key = Keys[0].Key;
                    break;

                default:
                    break;
            };

            return key;
        }
        #endregion Public Methods
    }
    #endregion Class

    #region Class
    public class ConnectionStrings
    {
        #region Properties
        public string Name { get; set; }

        public string Key { get; set; }
        #endregion Properties
    }
    #endregion Class
}