using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ProductsLearning.Data
{
    /// <summary>
    /// mongo entity interface
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// create date
        /// </summary>
        [BsonIgnore]
        DateTime CreatedOn { get; }

        /// <summary>
        /// id in string format
        /// </summary>
        [BsonId]
        string Id { get; set; }

        /// <summary>
        /// modify date
        /// </summary>
        DateTime ModifiedOn { get; }

        /// <summary>
        /// id in objectId format
        /// </summary>
        [BsonIgnore]
        ObjectId ObjectId { get; }
    }
}