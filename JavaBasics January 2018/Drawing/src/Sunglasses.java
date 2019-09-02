import java.util.Scanner;

public class Sunglasses {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);


        int n = Integer.parseInt(scanner.nextLine());

        String firstAndlastRow = reapetsStr("*", 2 * n) + reapetsStr(" ", 2 * n - n)
                + reapetsStr("*", 2 * n);
        System.out.println(firstAndlastRow);

        for (int i = 0; i < n - 2; i++) {
            String middle = "";
            String glass = "*" + reapetsStr("/", n * 2 - 2) + "*";
            if (i == ((n - 1) / 2) - 1) {
                 middle = reapetsStr("|", 2 * n - n);
            } else {
                 middle = reapetsStr(" ", 2 * n - n);
            }
        System.out.println(glass + middle + glass);
    }

        System.out.println(firstAndlastRow);
}

    static String reapetsStr(String strToRepeat, int count) {
        String text = "";
        for (int i = 0; i < count; i++) {
            text += strToRepeat;
        }
        return text;
    }
}