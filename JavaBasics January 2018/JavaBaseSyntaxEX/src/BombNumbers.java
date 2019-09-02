import java.util.ArrayList;
import java.util.Arrays;
import java.util.Scanner;

public class BombNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int[] intputNums = Arrays.stream(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();
        int[] steps = Arrays.stream(scanner.nextLine().split(" ")).mapToInt(Integer::parseInt).toArray();

        ArrayList<Integer> nums = new ArrayList<Integer>();
        for (int i = 0; i < intputNums.length; i++) {
            nums.add(intputNums[i]);
        }
        int bombNum = steps[0];
        int rangeNum = steps[1];

        for (int i = 0; i < nums.size(); i++) {
            if (nums.get(i) == bombNum){
                if (i - rangeNum >= 0){
                    for (int j = 0; j < rangeNum; j++) {
                        nums.remove(i - rangeNum + j);
                        i --;
                    }
                }else{
                    while (i != 0){
                        nums.remove(0);
                        i--;
                    }
                }
                if (i + rangeNum <= nums.size() - 1){
                    for (int j = 0; j < rangeNum; j++) {
                        nums.remove(i + rangeNum - j);
                    }
                }else{
                    while (i != nums.size() -1){
                        nums.remove( i + 1);
                    }
                }
                nums.remove(i);
                if (i != 0){
                    i--;
                }
            }
        }
        int sum = 0;
        for (int n :nums
                ) {
            sum+=n;
        }
        System.out.println(sum);
    }
}
