using System;
using System.Configuration;
using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ObjectBuilder;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.ObjectBuilder2;

namespace GenericCustomLog
{
    [Assembler(typeof(GenericLoggingExceptionHandlerAssembler))]
    [ContainerPolicyCreator(typeof(GenericLoggingExceptionHandlerAssembler))]
    public class GenericLogginExceptionHandlerData : ExceptionHandlerData
    {
        /// <summary>
        /// Represents configuration for a <see cref="GenericLoggingExceptionHandler"/>.
        /// </summary>

        private static readonly AssemblyQualifiedTypeNameConverter typeConverter
            = new AssemblyQualifiedTypeNameConverter();

        private const string logCategory = "logCategory";
        private const string eventId = "eventId";
        private const string severity = "severity";
        private const string title = "title";
        private const string formatterType = "formatterType";
        private const string priority = "priority";
        private const string moduleId = "moduleId";
        private const string layer = "layer";
        private const string mnemonic = "mnemonic";
        private const string subcategory = "subcategory";
        private const string useDefaultLogger = "useDefaultLogger";
        private const string replaceExceptionType = "replaceExceptionType";

        /// <summary>
        /// Initializes with default values.
        /// </summary>
        public GenericLogginExceptionHandlerData()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericLogginExceptionHandlerData"/> class.
        /// </summary>
        /// <param name="name">
        /// The name of the handler.
        /// </param>
        /// <param name="logCategory">
        /// The default log category.
        /// </param>
        /// <param name="eventId">
        /// The default eventID.
        /// </param>
        /// <param name="severity">
        /// The default severity.
        /// </param>
        /// <param name="title">
        /// The default title.
        /// </param>
        /// <param name="formatterType">
        /// The formatter type.
        /// </param>
        /// <param name="priority">
        /// The minimum value for messages to be processed.  Messages with a priority below the minimum are dropped immediately on the client.
        /// </param>
        public GenericLogginExceptionHandlerData(string name,
                                           string logCategory,
                                           int eventId,
                                           TraceEventType severity,
                                           string title,
                                           Type formatterType,
                                           int priority)
            : this(name, logCategory, eventId, severity, title, typeConverter.ConvertToString(formatterType), priority)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericLogginExceptionHandlerData"/> class.
        /// </summary>
        /// <param name="name">
        /// The name of the handler.
        /// </param>
        /// <param name="logCategory">
        /// The default log category.
        /// </param>
        /// <param name="eventId">
        /// The default eventID.
        /// </param>
        /// <param name="severity">
        /// The default severity.
        /// </param>
        /// <param name="title">
        /// The default title.
        /// </param>
        /// <param name="formatterTypeName">
        /// The formatter fully qualified assembly type name.
        /// </param>
        /// <param name="priority">
        /// The minimum value for messages to be processed.  Messages with a priority below the minimum are dropped immediately on the client.
        /// </param>
        public GenericLogginExceptionHandlerData(string name,
                                           string logCategory,
                                           int eventId,
                                           TraceEventType severity,
                                           string title,
                                           string formatterTypeName,
                                           int priority)
            : base(name, typeof(GenericLoggingExceptionHandler))
        {
            LogCategory = logCategory;
            EventId = eventId;
            Severity = severity;
            Title = title;
            FormatterTypeName = formatterTypeName;
            Priority = priority;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericLogginExceptionHandlerData"/> class.
        /// </summary>
        /// <param name="name">
        /// The name of the handler.
        /// </param>
        /// <param name="logCategory">
        /// The default log category.
        /// </param>
        /// <param name="eventId">
        /// The default eventID.
        /// </param>
        /// <param name="severity">
        /// The default severity.
        /// </param>
        /// <param name="title">
        /// The default title.
        /// </param>
        /// <param name="formatterTypeName">
        /// The formatter fully qualified assembly type name.
        /// </param>
        /// <param name="priority">
        /// The minimum value for messages to be processed.  Messages with a priority below the minimum are dropped immediately on the client.
        /// </param>
        /// <param name="useDefaultLogger">
        /// Use the default logger.
        /// </param>
        public GenericLogginExceptionHandlerData(string name,
                                           string logCategory,
                                           int eventId,
                                           int moduleId,
                                           TraceEventType severity,
                                           string title,
                                           string formatterTypeName,
                                           int priority,
                                           bool useDefaultLogger)
            : base(name, typeof(GenericLoggingExceptionHandler))
        {
            LogCategory = logCategory;
            EventId = eventId;
            ModuleId = moduleId;
            Severity = severity;
            Title = title;
            FormatterTypeName = formatterTypeName;
            Priority = priority;
            UseDefaultLogger = useDefaultLogger;
        }

        /// <summary>
        /// Gets or sets the default log category.
        /// </summary>
        [ConfigurationProperty(logCategory, IsRequired = true)]
        public string LogCategory
        {
            get { return (string)this[logCategory]; }
            set { this[logCategory] = value; }
        }

        /// <summary>
        /// Gets or sets the default event ID.
        /// </summary>
        [ConfigurationProperty(eventId, IsRequired = true)]
        public int EventId
        {
            get { return (int)this[eventId]; }
            set { this[eventId] = value; }
        }

        /// <summary>
        /// Gets or sets the default severity.
        /// </summary>
        [ConfigurationProperty(severity, IsRequired = true)]
        public TraceEventType Severity
        {
            get { return (TraceEventType)this[severity]; }
            set { this[severity] = value; }
        }

        /// <summary>
        ///  Gets or sets the default title.
        /// </summary>
        [ConfigurationProperty(title, IsRequired = true)]
        public string Title
        {
            get { return (string)this[title]; }
            set { this[title] = value; }
        }

        /// <summary>
        /// Gets or sets the formatter type.
        /// </summary>
        public Type FormatterType
        {
            get { return (Type)typeConverter.ConvertFrom(FormatterTypeName); }
            set { FormatterTypeName = typeConverter.ConvertToString(value); }
        }

        /// <summary>
        /// Gets or sets the formatter fully qualified assembly type name.
        /// </summary>
        /// <value>
        /// The formatter fully qualified assembly type name
        /// </value>
        [ConfigurationProperty(formatterType, IsRequired = true)]
        public string FormatterTypeName
        {
            get { return (string)this[formatterType]; }
            set { this[formatterType] = value; }
        }

        /// <summary>
        /// Gets or sets the minimum value for messages to be processed.  Messages with a priority
        /// below the minimum are dropped immediately on the client.
        /// </summary>
        [ConfigurationProperty(priority, IsRequired = true)]
        public int Priority
        {
            get { return (int)this[priority]; }
            set { this[priority] = value; }
        }

        /// <summary>
        /// Gets or sets the minimum value for messages to be processed.  Messages with a priority
        /// below the minimum are dropped immediately on the client.
        /// </summary>
        [ConfigurationProperty(moduleId, IsRequired = true)]
        public int ModuleId
        {
            get { return (int)this[moduleId]; }
            set { this[moduleId] = value; }
        }
        
        /// <summary>
        /// Gets or sets the layer in which the error ocurred. 
        /// below the minimum are dropped immediately on the client.
        /// </summary>
        [ConfigurationProperty(layer, IsRequired = true)]
        public int Layer
        {
            get { return (int)this[layer]; }
            set { this[layer] = value; }
        }

        /// <summary>
        /// Gets or sets the minimum value for messages to be processed.  Messages with a priority
        /// below the minimum are dropped immediately on the client.
        /// </summary>
        [ConfigurationProperty(mnemonic, IsRequired = true)]
        public string Mnemonic
        {
            get { return (string)this[mnemonic]; }
            set { this[mnemonic] = value; }
        }

        /// <summary>
        /// Gets or sets the minimum value for messages to be processed.  Messages with a priority
        /// below the minimum are dropped immediately on the client.
        /// </summary>
        [ConfigurationProperty(subcategory, IsRequired = true)]
        public string Subcategory
        {
            get { return (string)this[subcategory]; }
            set { this[subcategory] = value; }
        }

        /// <summary>
        /// Gets or sets the default logger to be used.
        /// </summary>
        [ConfigurationProperty(useDefaultLogger, IsRequired = false, DefaultValue = false)]
        public bool UseDefaultLogger
        {
            get { return (bool)this[useDefaultLogger]; }
            set { this[useDefaultLogger] = value; }
        }

        /// <summary>
        /// Gets or sets the type of the replacement exception.
        /// </summary>
        public Type ReplaceExceptionType
        {
            get { return (Type)typeConverter.ConvertFrom(ReplaceExceptionTypeName); }
            set { ReplaceExceptionTypeName = typeConverter.ConvertToString(value); }
        }
        /// <summary>
        /// Gets or sets the fully qualified type name of the replacement exception.
        /// </summary>
        /// <value>
        /// The fully qualified type name of the replacement exception.
        /// </value>
        [ConfigurationProperty(replaceExceptionType, IsRequired = true)]
        public string ReplaceExceptionTypeName
        {
            get { return (string)this[replaceExceptionType]; }
            set { this[replaceExceptionType] = value; }
        }
    }
        

    /// <summary>
    /// This type supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
    /// Represents the process to build a <see cref="LoggingExceptionHandler"/> described by a <see cref="LoggingExceptionHandlerData"/> configuration object.
    /// </summary>
    /// <remarks>This type is linked to the <see cref="LoggingExceptionHandlerData"/> type and it is used by the <see cref="ExceptionHandlerCustomFactory"/> 
    /// to build the specific <see cref="IExceptionHandler"/> object represented by the configuration object.
    /// </remarks>
    public class GenericLoggingExceptionHandlerAssembler : IAssembler<IExceptionHandler, ExceptionHandlerData>
    {
        /// <summary>
        /// This method supports the Enterprise Library infrastructure and is not intended to be used directly from your code.
        /// Builds an <see cref="LoggingExceptionHandler"/> based on an instance of <see cref="LoggingExceptionHandlerData"/>.
        /// </summary>
        /// <seealso cref="ExceptionHandlerCustomFactory"/>
        /// <param name="context">The <see cref="IBuilderContext"/> that represents the current building process.</param>
        /// <param name="objectConfiguration">The configuration object that describes the object to build. Must be an instance of <see cref="LoggingExceptionHandlerData"/>.</param>
        /// <param name="configurationSource">The source for configuration objects.</param>
        /// <param name="reflectionCache">The cache to use retrieving reflection information.</param>
        /// <returns>A fully initialized instance of <see cref="LoggingExceptionHandler"/>.</returns>
        public IExceptionHandler Assemble(IBuilderContext context,
                                          ExceptionHandlerData objectConfiguration,
                                          IConfigurationSource configurationSource,
                                          ConfigurationReflectionCache reflectionCache)
        {
            GenericLogginExceptionHandlerData castedObjectConfiguration
                = (GenericLogginExceptionHandlerData)objectConfiguration;

            LogWriter writer;
            if (castedObjectConfiguration.UseDefaultLogger)
            {
                writer = Logger.Writer;
            }
            else
            {
                IBuilderContext logWriterContext = context.CloneForNewBuild(NamedTypeBuildKey.Make<LogWriter>(), null);
                writer = (LogWriter)logWriterContext.Strategies.ExecuteBuildUp(logWriterContext);
            }

            GenericLoggingExceptionHandler createdObject
                = new GenericLoggingExceptionHandler(
                    castedObjectConfiguration.LogCategory,
                    castedObjectConfiguration.EventId,
                    castedObjectConfiguration.ModuleId,
                    castedObjectConfiguration.Severity,
                    castedObjectConfiguration.Title,
                    castedObjectConfiguration.Priority,
                    castedObjectConfiguration.FormatterType,
                    writer,
                    castedObjectConfiguration.ReplaceExceptionType,
                    castedObjectConfiguration.Layer,
                    castedObjectConfiguration.Mnemonic,
                    castedObjectConfiguration.Subcategory
                    );

            return createdObject;
        }
}
}
