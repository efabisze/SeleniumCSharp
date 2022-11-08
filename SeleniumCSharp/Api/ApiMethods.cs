//using System.Text;
using Newtonsoft.Json;
using RestSharp;

namespace SeleniumCSharp.Api
{
    class ApiMethods
    {
        public static RestResponse res;
        public static RestRequest request;

        public static UserDetails getUser(string userId)
        {

            string URL = Constants.BASEURL + Constants.USERS_ENDPOINT + "/" + userId;

            var resclient = new RestClient(URL);
            var request = new RestRequest(URL, Method.Get);

            var res = resclient.Execute(request);
            var obj = JsonConvert.DeserializeObject<UserDetails>(res.Content);
            
            return obj;
        }

        public static RestResponse getCallReturnResponse(String URL)
        {

            var resclient = new RestClient(URL);
            var request = new RestRequest(URL, Method.Get);

            var res = resclient.Execute(request);

            return res;
        }

        public static UserList getListUsers(String URL)
        {
            var resclient = new RestClient(URL);
            var request = new RestRequest(URL, Method.Get);

            var res = resclient.Execute(request);
            var obj = JsonConvert.DeserializeObject<UserList>(res.Content);

            return obj;

        }

        public static UsersResponseObject postWithJsonBodyParam(UsersRequestObject reqObject, String URL)
        {
            string reqObjectrequest = JsonConvert.SerializeObject(reqObject);

            var resclient = new RestClient(URL);
            var request = new RestRequest(URL, Method.Post);
            request.AddJsonBody(reqObjectrequest);

            var res = resclient.Execute(request);
            var obj = JsonConvert.DeserializeObject<UsersResponseObject>(res.Content);
            return obj;
        }
        public static UsersResponseObject putWithJsonBodyParam(UsersRequestObject userReqObject, String URL)
        {
            string reqObjectrequest = JsonConvert.SerializeObject(userReqObject);

            var resclient = new RestClient(URL);
            var request = new RestRequest(URL, Method.Put);
                request.AddJsonBody(reqObjectrequest);

            var res = resclient.Execute(request);
            var obj = JsonConvert.DeserializeObject<UsersResponseObject>(res.Content);

            return obj;
        }

        public static UsersResponseUpdateObject patchWithJsonBodyParam(UsersRequestObject userReqObject, String URL)
        {
            string reqObjectrequest = JsonConvert.SerializeObject(userReqObject);

            var resclient = new RestClient(URL);
            var request = new RestRequest(URL, Method.Patch);
            request.AddJsonBody(reqObjectrequest);

            var res = resclient.Execute(request);
            var obj = JsonConvert.DeserializeObject<UsersResponseUpdateObject>(res.Content);

            return obj;
        }
        public static RestResponse deleteWithPathParam(String URL)
        {
            request = new RestRequest(URL);
            res = new RestClient().Delete(request);
            return res;
        }

    }
}
