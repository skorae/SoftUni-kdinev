import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class MaxSequenceOfIncreasingElements {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] nums = Arrays.stream(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();

        int numLongest = 0;
        int diff = 0;
        ArrayList<Integer> longest = new ArrayList<Integer>();

        if (nums.length == 1) {
            System.out.print(nums[0]);
            return;
        }

        for (int i = 1; i < nums.length; i++) {
            ArrayList<Integer> temp = new ArrayList<Integer>();
            if (nums[i] - nums[i - 1] >= 1) {
                int count = 1;
                temp.add(nums[i - 1]);
                for (int j = i; j < nums.length; j++) {
                    if (nums[j] <= nums[j - 1]) {
                        i = j;
                        break;
                    }
                    temp.add(nums[j]);
                    count++;
                    i = j;
                }
                if (numLongest < count) {
                    numLongest = count;
                    longest = temp;
                }
            }
        }
        for (int i = 0; i < longest.size(); i++) {
            System.out.print(longest.get(i) + " ");
        }
    }
}
