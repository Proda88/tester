using System.Net;
using Newtonsoft.Json;
using Part2_RestSharp_APITest.Model;
using RestSharp;
using Xunit;
namespace Part2_RestSharp_APITest;

public class UnitTest1
{
    [Theory(DisplayName ="Statuscode OK after GET method")]
    [InlineData("posts")]
    [InlineData("comments")]
    [InlineData("photos")]
    [InlineData("comments?postId=1")]
    public void StatusCodeCheck(string parametar)
    {
        //Arrange
        RestClient client = new RestClient("https://jsonplaceholder.typicode.com");
        RestRequest request = new RestRequest($"{parametar}", Method.Get);

        //Act
        RestResponse response = client.Execute(request);

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

   
        [Theory(DisplayName = "Content not empty after GET method")]
        [InlineData("posts")]
        [InlineData("comments")]
        [InlineData("photos")]
        [InlineData("comments?postId=1")]
        public void ContentCheck(string parametar)
    {
        //Arrange
        RestClient client = new RestClient("https://jsonplaceholder.typicode.com");
        RestRequest request = new RestRequest($"{parametar}", Method.Get);

        //Act
        RestResponse response = client.Execute(request);

        //Assert
        Assert.NotEmpty(response.Content);
    }

    [Fact(DisplayName ="Check number of comments")]
    public void CheckCommentNumber()
    {
        //Arange
        RestClient client = new RestClient("https://jsonplaceholder.typicode.com");
        RestRequest request = new RestRequest("comments?postId=1", Method.Get);

        //Act
        RestResponse response = client.Execute(request);
        List<PlaceModel> comments = JsonConvert.DeserializeObject<List<PlaceModel>>(response.Content);

        //Assert
        Assert.Equal(5, comments.Count);
    }

}
