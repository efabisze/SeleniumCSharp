class Constants
{
    public TestContext context { get; set; }

    public static String API_ENDPOINT = "/api";
    public static String USERS_ENDPOINT = API_ENDPOINT + "/users";
    public static String LOGIN_ENDPOINT = API_ENDPOINT + "/login";
    public static String BASEURL = "https://reqres.in";
    public const string REGRESSION = nameof(REGRESSION);
}

