namespace Application.Core.Specification.Course
{
    using System;
    using System.Linq.Expressions;

    /// TODO: update spec document

    /// <summary>
    /// Base contract for Specification pattern with Linq and
    /// lambda expression support
    /// Ref : http://gpa.com/spec.pdf
    /// Ref : http://en.wikipedia.org/wiki/Specification_pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T> where T : class
    {
        /// <summary>
        /// Check if this specification is satisfied by a 
        /// specific expression lambda
        /// </summary>
        /// <returns></returns>
        Expression<Func<T, bool>> SatisfiedBy();
    }
}
