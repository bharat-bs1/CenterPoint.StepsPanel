namespace Tutkoo.mintyfusion.CenterPoint.StepsPanel.Model
{
    #region namespace
    using Newtonsoft.Json;
    using NPoco;
    #endregion namespace

    #region Class
    [TableName("Steps")]
    [PrimaryKey("Id", AutoIncrement = false)]
    public class StepModel : EntityBase
    {
        #region Properties
        /// <summary>TypeId</summary>
        [JsonProperty(PropertyName = "typeId")]
        public int TypeId { get; set; }
        #endregion
    }
    #endregion
}
