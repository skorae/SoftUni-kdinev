import java.util.Scanner;

public class P04 {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        char num = 0;
        char capLat = 0;
        char smallLat = 0;
        char left = 0;
        String to9 = "";
        String big = "";
        String lit = "";
        String rest = "";

        for (int i = 0; i < n; i++) {
            char a = scanner.nextLine().charAt(0);

            if (a >= '0' && a <= '9') {
                to9 += "" + a;
                num += a;
            } else if (a >= 'A' && a <= 'Z') {
                big += "" + a;
                capLat += a;
            } else if (a >= 'a' && a <= 'z') {
                lit += "" + a;
                smallLat += a;
            } else {
                rest += "" + a;
                left += a;
            }
        }
        if (num > capLat && num > smallLat && num > left) {
            System.out.printf("Biggest ASCII sum is:%d\n", (int) num);
            System.out.printf("Combination of characters is:%s", to9);
        } else if (capLat > num && capLat > smallLat && capLat > left) {
            System.out.printf("Biggest ASCII sum is:%d\n", (int) capLat);
            System.out.printf("Combination of characters is:%s", big);
        } else if (smallLat > num && smallLat > capLat && smallLat > left) {
            System.out.printf("Biggest ASCII sum is:%d\n", (int) smallLat);
            System.out.printf("Combination of characters is:%s", lit);
        } else if (left > num && left > capLat && left > smallLat) {
            System.out.printf("Biggest ASCII sum is:%d\n", (int) left);
            System.out.printf("Combination of characters is:%s", rest);
        }
    }
}
