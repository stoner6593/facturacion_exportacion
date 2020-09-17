﻿namespace System.ComponentModel.DataAnnotations
{
    /// <summary>
    /// Indicates whether the consumer of a field or property, such as a client application,
    /// should allow editing of the value.
    /// </summary>
    /// <remarks>
    /// This attribute neither enforces nor guarantees editability; the underlying data
    /// store might allow changing the data regardless of this attribute.  The presence
    /// of this attribute signals intent to the consumer of the attribute whethere or not
    /// the end user should be allowed to change the value via the client application.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class EditableAttribute : Attribute
    {
        /// <summary>
        /// Indicates whether or not the field/property allows editing of the
        /// value.
        /// </summary>
        /// <value>
        /// When <c>true</c>, the field/property is editable.
        /// <para>
        /// When <c>false</c>, the field/property is not editable.
        /// </para>
        /// </value>
        public bool AllowEdit { get; private set; }

        /// <summary>
        /// Indicates whether or not the field/property allows an initial value
        /// to be specified.
        /// </summary>
        /// <remarks>
        /// The value of this property defaults to match the <see cref="AllowEdit"/>
        /// property value specified in the constructor.
        /// </remarks>
        /// <value>
        /// When <c>true</c>, the field/property can have its value set for
        /// newly constructed instances, such as during an insert operation.
        /// <para>
        /// When <c>false</c>, the field/property cannot have its
        /// value provided for newly constructed instances, such as during
        /// an insert operation.  This will often indicate that the value
        /// is auto-generated by the persistence store.
        /// </para>
        /// </value>
        public bool AllowInitialValue { get; set; }

        /// <summary>
        /// Indicate whether or not a field/property is editable.
        /// </summary>
        /// <param name="allowEdit">
        /// Indicates whether the field/property is editable.  The value provided
        /// will apply to both <see cref="AllowEdit"/> and
        /// <see cref="AllowInitialValue"/> unless the <see cref="AllowInitialValue"/>
        /// property is explicitly specified.
        /// </param>
        public EditableAttribute(bool allowEdit)
        {
            this.AllowEdit = allowEdit;
            this.AllowInitialValue = allowEdit;
        }
    }
}