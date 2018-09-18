namespace Tutkoo.mintyfusion.CenterPoint.StepsPanel.Controllers
{
    #region namespace
    using log4net;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Model;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;
    using Tasks;
    #endregion namespace

    #region Class
    public class StepController : Controller
    {
        #region Fields
        private readonly IOptions<AppSettingsModel> optionsAccessor;

        private AppSettingsModel appSettings = null;

        private readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private string loggingMessagePrefix = string.Empty;
        #endregion Fields

        #region Constructor
        public StepController(IOptions<AppSettingsModel> optionsAccessor)
        {
            this.optionsAccessor = optionsAccessor;

            if (optionsAccessor.Value.Keys != null & optionsAccessor.Value.Keys.Length >= 1)
                appSettings = optionsAccessor.Value;
        }
        #endregion Constructor

        #region Public Methods
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<StepModel>>> Details()
        {
            //if (id == null)
            //{
            //    return NotFound();
            //}

            CommonDatabaseTasks<StepModel> databaseTasks = new CommonDatabaseTasks<StepModel>(appSettings.GetKey(ConnectionType.SqlServer));

            var movie = await databaseTasks.GetAsync();
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
        #endregion Public Methods
    }
    #endregion Class
}