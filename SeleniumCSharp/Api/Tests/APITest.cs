using RestSharp;
using System.Net;
using System.Text.Json.Nodes;
using System.Text.Json;
using Newtonsoft.Json;

namespace SeleniumCSharp.Api.Tests

{

    public class Tests
    {
        string baseURL = "https://reqres.in/";

        /// <summary>
        /// Basic get user and validate all info returned
        /// </summary>
        [Test]
        [Category(Constants.REGRESSION)]
        public void getUser()
        {
            var response = ApiMethods.getUser("2");
            
            Assert.That(response.Data.id, Is.EqualTo(2));
            Assert.That(response.Data.first_name, Is.EqualTo("Janet"));
            Assert.That(response.Data.email, Is.EqualTo("janet.weaver@reqres.in"));
            Assert.That(response.Data.last_name, Is.EqualTo("Weaver"));
            Assert.That(response.Data.avatar, Is.EqualTo("https://reqres.in/img/faces/2-image.jpg"));

        }

        /// <summary>
        /// Get full list of users on a certain page
        /// </summary>
        [Test]
        [Category(Constants.REGRESSION)]
        public void getListOfUsers()
        {
            var response = ApiMethods.getListUsers(baseURL + "api/users?page=2");

            Assert.That(response.Data.Count, Is.EqualTo(6));

            Assert.That(response.Data[0].id, Is.EqualTo(7));
            Assert.That(response.Data[0].first_name, Is.EqualTo("Michael"));
            Assert.That(response.Data[0].email, Is.EqualTo("michael.lawson@reqres.in"));
            Assert.That(response.Data[0].last_name, Is.EqualTo("Lawson"));
            Assert.That(response.Data[0].avatar, Is.EqualTo("https://reqres.in/img/faces/7-image.jpg"));
        }

        /// <summary>
        /// Get a user that returns a not found response
        /// </summary>
        [Test]
        [Category(Constants.REGRESSION)]
        public void getUserNotFound()
        {
            //have to use user 23
            var response = ApiMethods.getCallReturnResponse(baseURL + "api/users/23");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        /// <summary>
        /// update user and verify its response
        /// </summary>
        [Test]
        [Category(Constants.REGRESSION)]
        public void putUpdateUser()
        {
            var reqObject = new UsersRequestObject();
            reqObject.name = "morpheus";
            reqObject.job = "leader";

            var response = ApiMethods.putWithJsonBodyParam(reqObject, baseURL + "api/users/2");
            Assert.That(response.name, Is.EqualTo("morpheus"));
            Assert.That(response.job, Is.EqualTo("leader"));
        }

        /// <summary>
        /// utilize patch call to patch call an empty user
        /// </summary>
        [Test]
        [Category(Constants.REGRESSION)]
        public void patchUpdateEmptyUser()
        {
            var reqObject = new UsersRequestObject();

            var response = ApiMethods.patchWithJsonBodyParam(reqObject, baseURL + "api/users/2");

            DateTime now = DateTime.Now.AddHours(5); // seems to be the server in different timezone, changes with DST also

            Assert.That(response.name, Is.Null);
            Assert.That(response.job, Is.Null);

            Console.WriteLine(now.ToString());
            Console.WriteLine(response.updatedAt);
            Assert.True(Math.Abs((response.updatedAt - now).TotalSeconds) <= 1);


        }

        /// <summary>
        /// create user that is empty and will have no name or job
        /// </summary>
        [Test]
        [Category(Constants.REGRESSION)]
        public void createUserEmptyUser()
        {
            var reqObject = new UsersRequestObject();

            var response = ApiMethods.postWithJsonBodyParam(reqObject, baseURL + "api/users/2");
            DateTime now = DateTime.Now.AddHours(5); // seems to be the server in different timezone

            Assert.That(response.name, Is.Null);
            Assert.That(response.job, Is.Null);

            Assert.True(Math.Abs((response.createdAt - now).TotalSeconds) <= 1);
        }

        /// <summary>
        /// Deleting returns no content
        /// </summary>
        [Test]
        [Category(Constants.REGRESSION)]
        public void deleteUser()
        {

            var response = ApiMethods.deleteWithPathParam(baseURL + "api/users/2");

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
    }

}
