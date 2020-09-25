public static class Utils
{
    public static void Sentinel(ref int sentinel)
    {
        sentinel -= 1;
        if (sentinel <= 0) {
            throw new System.Exception("Sentinel exceeded");
        }
    }
}
