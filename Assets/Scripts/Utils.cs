// Custom Utils class for random computations implemented as static methods
public class Utils {
    // A custom mod function is implemented for computing indexes, because
    // C#'s mod doesn't work for negative integers :)
    // https://stackoverflow.com/questions/1082917/mod-of-negative-number-is-melting-my-brain
    public static int indexMod(int x, int m) {
        int r = x%m;
        return r<0 ? r+m : r;
    }
}