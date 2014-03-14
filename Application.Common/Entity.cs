namespace Application.Common
{
    using System;

    /// <summary>
    /// Base class for entities
    /// </summary>
    public abstract class Entity
    {
        #region Members

        int? _requestedHashCode;

        #endregion Members

        #region Properties

        #endregion Properties

        #region Public Methods


        #endregion Public Methods

        #region Overrides Methods


        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        #endregion
    }
}
