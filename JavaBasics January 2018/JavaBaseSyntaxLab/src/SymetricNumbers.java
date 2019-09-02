import java.util.ArrayList;
import java.util.Scanner;

public class SymetricNumbers {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        ArrayList nums = new ArrayList();

        for (int i = 1; i <= n; i++) {
            if (i < 10) {
                nums.add(i);
            } else {
                if (Num(i) != 0){
                    nums.add(i);
                }
            }

        }
        System.out.print(nums);
    }

    private static int Num(int i) {
        int a = i % 10;
        int b = 0;
        int c = i;
        while (c > 0) {

            c = c % 10;
            if (c > 0) {
                b = c;
            }
            i -= c;
        }
        if (a == b){
            return i;
        }
        return 0;
    }
}
