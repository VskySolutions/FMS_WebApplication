using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Vsky.Api.Framework.Models
{
    public partial record BaseModel
    {
        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public BaseModel()
        {
            CustomProperties = new Dictionary<string, string>();

            PostInitialize();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Perform additional actions for binding the model
        /// </summary>
        /// <param name="bindingContext">Model binding context</param>
        /// <remarks>Developers can override this method in custom partial classes in order to add some custom model binding</remarks>
        public virtual void BindModel(ModelBindingContext bindingContext)
        {
        }

        /// <summary>
        /// Perform additional actions for the model initialization
        /// </summary>
        /// <remarks>Developers can override this method in custom partial classes in order to add some custom initialization code to constructors</remarks>
        protected virtual void PostInitialize()
        {
        }

        #endregion

        #region Properties

        public Dictionary<string, string> CustomProperties { get; set; }

        #endregion
    }
}