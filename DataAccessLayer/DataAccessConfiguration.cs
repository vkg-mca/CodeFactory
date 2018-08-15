using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Configuration
{
    public class DataAccessConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("Transaction")]
        public Transaction Transaction
        {
            get { return (Transaction)this["Transaction"]; }
            set { this["Transaction"] = value; }
        }
    }
    public class Transaction : ConfigurationElement
    {
        [ConfigurationProperty("Operation")]
        public Operation Operation
        {
            get { return (Operation)this["Operation"]; }
            set { this["Operation"] = value; }
        }
        
        [ConfigurationProperty("Parameters")]
        public ParameterCollection ParameterCollection
        {
            get { return (ParameterCollection)this["Parameters"]; }
            set { this["Parameters"] = value; }
        }

    }

    public class Operation : ConfigurationElement
    {
        [ConfigurationProperty("Name", DefaultValue = "")]
        public string Name
        {
            get { return this["Name"].ToString(); }
            set { this["Name"] = value; }
        }
        //[ConfigurationProperty("Code", DefaultValue = "")]
        //public string Code
        //{
        //    get { return this["Code"].ToString(); }
        //    set { this["Code"] = value; }
        //}

    }
 
    public class Parameter : ConfigurationElement
    {

        private static ConfigurationProperty s_propName;
        private static ConfigurationProperty s_propType;
        private static ConfigurationProperty s_propNullable;
        private static ConfigurationProperty s_direction;
        //private static ConfigurationProperty s_setId;
        private static ConfigurationPropertyCollection s_properties;

        /// <summary>
        /// Predefines the valid properties and prepares
        /// the property collection.
        /// </summary>
        static Parameter()
        {
            // Predefine properties here
            s_propName = new ConfigurationProperty("Name", typeof(string), string.Empty, ConfigurationPropertyOptions.IsRequired);
            s_propType = new ConfigurationProperty("Type", typeof(string), string.Empty, ConfigurationPropertyOptions.IsRequired);
            s_propNullable = new ConfigurationProperty("Nullable", typeof(string), string.Empty, ConfigurationPropertyOptions.IsRequired);
            s_direction = new ConfigurationProperty("Direction", typeof(string), string.Empty, ConfigurationPropertyOptions.IsRequired);
            //s_setId = new ConfigurationProperty("SetId", typeof(string), string.Empty, ConfigurationPropertyOptions.IsRequired);
            s_properties = new ConfigurationPropertyCollection();

            s_properties.Add(s_propName);
            s_properties.Add(s_propType);
            s_properties.Add(s_propNullable);
            s_properties.Add(s_direction);
            //s_properties.Add(s_setId);
        }


        /// <summary>
        /// Gets the Name setting.
        /// </summary>
        [ConfigurationProperty("Name", IsRequired = true)]
        public string Name
        {
            get { return (string)base[s_propName]; }
        }

        /// <summary>
        /// Gets the Type setting.
        /// </summary>
        [ConfigurationProperty("Type")]
        public string Type
        {
            get { return (string)base[s_propType]; }
        }

        /// <summary>
        /// Gets the Type setting.
        /// </summary>
        [ConfigurationProperty("Nullable")]
        public string Nullable
        {
            get { return (string)base[s_propNullable]; }
        }
        /// </summary>
        [ConfigurationProperty("Direction")]
        public string Direction
        {
            get { return (string)base[s_direction]; }
        }
        //[ConfigurationProperty("SetId")]
        //public string SetId
        //{
        //    get { return (string)base[s_setId]; }
        //}
        /// <summary>
        /// Override the Properties collection and return our custom one.
        /// </summary>
        protected override ConfigurationPropertyCollection Properties
        {
            get { return s_properties; }
        }
    }


    [ConfigurationCollection(typeof(Parameter),
    CollectionType = ConfigurationElementCollectionType.AddRemoveClearMap)]
    public class ParameterCollection : ConfigurationElementCollection
    {
        private static ConfigurationPropertyCollection m_properties;

        static ParameterCollection()
        {
            m_properties = new ConfigurationPropertyCollection();
        }
        public ParameterCollection()
        {
        }
        protected override ConfigurationPropertyCollection Properties
        {
            get { return m_properties; }
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }
        public Parameter this[int index]
        {
            get { return (Parameter)base.BaseGet(index); }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                base.BaseAdd(index, value);
            }
        }
        public Parameter this[string name]
        {
            get { return (Parameter)base.BaseGet(name); }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new Parameter();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as Parameter).Name;
        }
    }

}
