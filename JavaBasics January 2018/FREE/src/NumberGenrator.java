import java.util.Scanner;

public class NumberGenrator {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int m = Integer.parseInt(scanner.nextLine());
        int n = Integer.parseInt(scanner.nextLine());
        int l = Integer.parseInt(scanner.nextLine());
        int specialNum = Integer.parseInt(scanner.nextLine());
        int controlNum = Integer.parseInt(scanner.nextLine());

        int mnl = m * 100 + n * 10 + l;

        while (specialNum < controlNum && mnl >= 111) {
            if (mnl % 3 == 0) {
                specialNum += 5;
            } else if (mnl % 10 == 5) {
                specialNum -= 2;
            } else if (mnl % 2 == 0) {
                specialNum *= 2;
            }
            mnl -= 1;
            if (mnl % 10 == 0) {
                mnl = mnl - 10 + l;
                if (mnl % 100 / 10 == 0) {
                    mnl = mnl - 100 + n * 10;
                }
            }

        }
        if (specialNum >= controlNum) {
            System.out.printf("Yes! Control number was reached! Current special number is %d.", specialNum);
        } else {
            System.out.printf("No! %d is the last reached special number.", specialNum);
        }
    }
}