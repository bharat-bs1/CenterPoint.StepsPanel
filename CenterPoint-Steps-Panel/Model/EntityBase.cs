namespace Tutkoo.mintyfusion.CenterPoint.StepsPanel.Model
{
    #region namespace
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    #endregion namespace

    #region Class
    public class EntityBase
    {
        #region Properties
        /// <summary>Unique ID</summary>        
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>Description</summary>
        [StringLength(50), JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>Description</summary>
        [StringLength(256), JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        #endregion
    }
    #endregion
}