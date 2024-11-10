using System.Globalization;
using System.Reflection;
using System;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Configuration;

namespace Recruitment.Helper
{
    public class CsvReader 
    {
        //private bool disposed;
        //private readonly bool hasHeaderRecord;
        //private string[] headerRecord;



        //public virtual async IAsyncEnumerable<T> GetRecordsAsync<T>([EnumeratorCancellation] CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    if (disposed)
        //    {
        //        throw new ObjectDisposedException("CsvReader", "GetRecords<T>() returns an IEnumerable<T> that yields records. This means that the method isn't actually called until you try and access the values. Did you create CsvReader inside a using block and are now trying to access the records outside of that using block?");
        //    }

        //    if (hasHeaderRecord && headerRecord == null)
        //    {
        //        if (!(await ReadAsync().ConfigureAwait(continueOnCapturedContext: false)))
        //        {
        //            yield break;
        //        }

        //        ReadHeader();
        //        ValidateHeader<T>();
        //    }

        //    Func<T> read = null;
        //    while (await ReadAsync().ConfigureAwait(continueOnCapturedContext: false))
        //    {
        //        cancellationToken.ThrowIfCancellationRequested();
        //        T val;
        //        try
        //        {
        //            if (read == null)
        //            {
        //                read = recordManager.Value.GetReadDelegate<T>(typeof(T));
        //            }

        //            val = read();
        //        }
        //        catch (Exception ex)
        //        {
        //            CsvHelperException ex2 = (ex as CsvHelperException) ?? new ReaderException(context, "An unexpected error occurred.", ex);
        //            ReadingExceptionOccurredArgs args = new ReadingExceptionOccurredArgs(ex2);
        //            if (readingExceptionOccurred?.Invoke(args) ?? true)
        //            {
        //                if (ex is CsvHelperException)
        //                {
        //                    throw;
        //                }

        //                throw ex2;
        //            }

        //            continue;
        //        }

        //        yield return val;
        //    }
        //}

        //public virtual async Task<bool> ReadAsync()
        //{
        //    bool flag;
        //    do
        //    {
        //        flag = await parser.ReadAsync().ConfigureAwait(continueOnCapturedContext: false);
        //        hasBeenRead = true;
        //    }
        //    while (flag && (shouldSkipRecord?.Invoke(new ShouldSkipRecordArgs(this)) ?? false));
        //    currentIndex = -1;
        //    if (detectColumnCountChanges && flag)
        //    {
        //        if (prevColumnCount > 0 && prevColumnCount != parser.Count)
        //        {
        //            BadDataException ex = new BadDataException(string.Empty, parser.RawRecord, context, "An inconsistent number of columns has been detected.");
        //            ReadingExceptionOccurredArgs args = new ReadingExceptionOccurredArgs(ex);
        //            if (readingExceptionOccurred?.Invoke(args) ?? true)
        //            {
        //                throw ex;
        //            }
        //        }

        //        prevColumnCount = parser.Count;
        //    }

        //    return flag;
        //}


    }
}
