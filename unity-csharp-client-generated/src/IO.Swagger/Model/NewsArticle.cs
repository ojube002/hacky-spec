namespace Hacky.models {


    public struct NewsArticle { 
        public long? Id;
        public string Title;
        public string Contents;
        public string ImageUrl;
        public DateTime? CreatedAt;
        public DateTime? UpdatedAt;

    public void ToJson(){
        return JsonUtility.ToJson(this);
    }
    }


}
