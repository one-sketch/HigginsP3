using System.Net.Http.Headers;

namespace HigginsP3.Services
{
    public class DataRetrieval
    {
        /*
         * Task vs thread
         * Task has async/await and a return value (no direct way to return from a thread)
         * task can do multiple things, thread is one thing
         * we can cancel a task
         * Task is a higher level concept than a thread
         */

        //string d - something like "about/", or "people/"
        public async Task<string> GetData(string d) {

            //using statement - at end of using auto calls dispose method
            using (var client = new HttpClient() )
            {
                //where all of the calls are going...
                client.BaseAddress = new Uri("https://ischool.gccis.rit.edu/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    //create an object to put the response in
                    HttpResponseMessage response = await client.GetAsync(d, HttpCompletionOption.ResponseHeadersRead);
                    //is it 200?
                    response.EnsureSuccessStatusCode();
                    //let's finally do something - go get it!
                    var data = await response.Content.ReadAsStringAsync();
                    //data is just a string
                    return data;

                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    return "HttpReq: " + msg;
                }
                catch (Exception e)
                {
                    var msg = e.Message;
                    return "Exc: " + msg;
                }
                
               


            }

        }
    }
}
