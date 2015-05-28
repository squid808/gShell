using System;
using System.Threading.Tasks;
using Google.Apis.Json;
using Google.Apis.Util.Store;

namespace gShell.dotNet.Utilities
{
    class MemoryObjectDataStore : IDataStore
    {
        public static string tokenTemp;

        /// <summary>
        /// 
        /// </summary>
        public Task StoreAsync<T>(string key, T value)
        {
            tokenTemp = NewtonsoftJsonSerializer.Instance.Serialize(value);
            return TaskEx.Delay(0);
        }

        /// <summary>
        /// 
        /// </summary>
        public Task DeleteAsync<T>(string key)
        {
            SavedFile.RemoveDomain(key);
            return TaskEx.Delay(0);
        }

        /// <summary>
        /// 
        /// </summary>
        public Task<T> GetAsync<T>(string key)
        {
            TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();

            if (SavedFile.ContainsUserOrDomain(key))
            {
                string response = SavedFile.LoadToken(key);
                tokenTemp = response;
                tcs.SetResult(NewtonsoftJsonSerializer.Instance.Deserialize<T>(response));
            }
            else
            {
                tcs.SetResult(default(T));
            }
            return tcs.Task;
        }

        /// <summary>
        /// 
        /// </summary>
        public Task ClearAsync()
        {
            SavedFile.ClearAllTokens();
            return TaskEx.Delay(0);
        }
    }

    //class GmailObjectDataStore : IDataStore
    //{
    //    public static string tokenTemp;

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public Task StoreAsync<T>(string key, T value)
    //    {
    //        tokenTemp = NewtonsoftJsonSerializer.Instance.Serialize(value);
    //        return TaskEx.Delay(0);
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public Task DeleteAsync<T>(string key)
    //    {
    //        SavedFile.DeleteToken(key);
    //        return TaskEx.Delay(0);
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public Task<T> GetAsync<T>(string key)
    //    {
    //        TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();

    //        if (SavedFile.ContainsUserOrDomain(key))
    //        {
    //            string response = SavedFile.LoadToken(key);
    //            tcs.SetResult(NewtonsoftJsonSerializer.Instance.Deserialize<T>(response));
    //        }
    //        else
    //        {
    //            tcs.SetResult(default(T));
    //        }
    //        return tcs.Task;
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public Task ClearAsync()
    //    {
    //        SavedFile.ClearAllTokens();
    //        return TaskEx.Delay(0);
    //    }
    //}
}
