import java.util.Scanner;

public class GroupName {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        char first = scanner.nextLine().charAt(0);
        char second = scanner.nextLine().charAt(0);
        char third = scanner.nextLine().charAt(0);
        char fourth = scanner.nextLine().charAt(0);
        int num = Integer.parseInt(scanner.nextLine());
        int count = -1;

        for (char i = 'A'; i <= first; i++) {
            for (char j = 'a'; j <= second; j++) {
                for (char k = 'a'; k <= third; k++) {
                    for (char l = 'a'; l <= fourth; l++) {
                        for (int m = 0; m <= num; m++) {

                            count++;
                        }
                    }
                }
            }
        }
        System.out.println(count);
    }
}
