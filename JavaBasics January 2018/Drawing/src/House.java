import java.util.Scanner;

public class House {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);


        int n = Integer.parseInt(scanner.nextLine());
        int stars = 0;

        if (n % 2 == 0) {
            stars = 2;
        } else {
            stars = 1;
        }


        for (int i = 0; i < (n + 1) / 2; i++) {

            String roof = reapetsStr("-", (n - stars) / 2)
                    + reapetsStr("*", stars) + reapetsStr("-", (n - stars) / 2);
            stars += 2;
            System.out.println(roof);
        }

        for (int j = 0; j < n / 2; j++) {
            String base = "|" + reapetsStr("*", n - 2) + "|";
            System.out.println(base);
        }

    }


    static String reapetsStr(String strToRepeat, int count) {
        String text = "";
        for (int i = 0; i < count; i++) {
            text += strToRepeat;
        }
        return text;
    }
}
