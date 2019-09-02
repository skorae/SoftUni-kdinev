import java.util.Arrays;
import java.util.Scanner;

public class MaxSequenceOfEqualElements {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] nums = Arrays.stream(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();

        int longCount = 0;
        int numLongest = 0;

        for (int i = 1; i < nums.length; i++) {
            if (nums[i] == nums[i - 1]) {
                int count = 1;
                int temp = 0;
                for (int j = i; j < nums.length; j++) {
                    if (nums[j] != nums[i]) {
                        i = j;
                        break;
                    }
                    count++;
                    temp = nums[i];
                }
                if (longCount < count){
                    longCount = count;
                    numLongest = temp;
                }
            }
        }
        for (int i = 0; i < longCount; i++) {
            System.out.print(numLongest + " ");
        }
    }
}
