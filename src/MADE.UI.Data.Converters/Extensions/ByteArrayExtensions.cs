// MADE Apps licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace MADE.UI.Data.Converters.Extensions
{
    using System;
    using System.IO;
    using Windows.Storage.Streams;
    using Windows.UI.Xaml.Media.Imaging;

    /// <summary>
    /// Defines a collection of extensions for <see cref="byte"/> array instances.
    /// </summary>
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Converts an array of bytes representing an image into a <see cref="BitmapSource"/>.
        /// </summary>
        /// <param name="imageBytes">
        /// The image bytes.
        /// </param>
        /// <returns>
        /// Returns a <see cref="BitmapSource"/> of the specified bytes.
        /// </returns>
        public static BitmapSource ToBitmapSource(this byte[] imageBytes)
        {
            BitmapSource bitmapSource = new BitmapImage();

#if WINDOWS_UWP
            using var raStream = new InMemoryRandomAccessStream();
            using (var writer = new DataWriter(raStream))
            {
                // Write the bytes to the stream
                writer.WriteBytes(imageBytes);

                // Store the bytes to the MemoryStream
                writer.StoreAsync().GetAwaiter().GetResult();

                // Detach from the Memory stream so we don't close it
                writer.DetachStream();
            }

            raStream.Seek(0);

            bitmapSource.SetSource(raStream);
#else
            bitmapSource.SetSource(new MemoryStream(imageBytes) { Position = 0 });
#endif

            return bitmapSource;
        }
    }
}
