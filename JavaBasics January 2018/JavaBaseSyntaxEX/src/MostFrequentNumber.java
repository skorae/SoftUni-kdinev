import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class MostFrequentNumber {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] nums = Arrays.stream(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();
        ArrayList<Integer> n = new ArrayList<Integer>();

        for (int i = 0; i < nums.length; i++) {
            n.add(nums[i]);
        }

        int mostFrequentNum = 0;
        long bigCount = 0;
        long tempCount = 0;
        int tempNum = 0;

        for (int i = 0; i < n.size(); i++) {
            tempNum = n.get(i);

            for (int j = i; j < n.size(); j++) {
                if (n.get(j) == tempNum){
                    tempCount++;
                    n.remove(j);
                    j--;
                }
            }
            if (bigCount < tempCount){
                bigCount = tempCount;
                mostFrequentNum = tempNum;
            }
            tempCount = 0;
            i--;
        }
        System.out.println(mostFrequentNum);
    }
}
