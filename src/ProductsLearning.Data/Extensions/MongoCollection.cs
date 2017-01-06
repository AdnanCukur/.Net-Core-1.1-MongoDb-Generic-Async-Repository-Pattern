using MongoDB.Driver;

namespace ProductsLearning.Data.Extensions {
    public static class MongoCollectionExtension {
        public static long GetTotalDataSize(this MongoCollection src) {
            var totalSize = src.GetStats().DataSize;
            foreach (var index in src.GetIndexes()) {
                var indexCollectionName = string.Format("{0}.${1}", src.Name, index.Name);
                var indexCollection = src.Database.GetCollection(indexCollectionName);
                totalSize += indexCollection.GetStats().DataSize;
            }
            return totalSize;
        }
        /// <summary>
        /// Gets the total storage size for this collection (data + indexes + overhead).
        /// </summary>
        /// <returns>The total storage size.</returns>
        public static long GetTotalStorageSize(this MongoCollection src) {
            var totalSize = src.GetStats().StorageSize;
            foreach (var index in src.GetIndexes()) {
                var indexCollectionName = string.Format("{0}.${1}", src.Name, index.Name);
                var indexCollection = src.Database.GetCollection(indexCollectionName);
                totalSize += indexCollection.GetStats().StorageSize;
            }
            return totalSize;
        }
    }
}
