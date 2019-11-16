namespace Hacky.models {


    public struct Character { 
        public string Id;
        public string Name;
        public long? Level;
        public long? Experience;
        public DateTime? CreatedAt;
        public DateTime? UpdatedAt;

    public void ToJson(){
        return JsonUtility.ToJson(this);
    }
    }


}
