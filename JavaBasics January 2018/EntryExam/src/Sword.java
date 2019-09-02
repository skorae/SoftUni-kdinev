import java.util.Scanner;

public class Sword {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);


        int n = Integer.parseInt(scanner.nextLine());

        for (int i = 0; i < n / 2 + 1; i++) {
            if (i == 0){
                String firstRow = reapetsStr("#", n - 1) + "/^\\"
                        + reapetsStr("#", n - 1);
                System.out.println(firstRow);
            }else{
                String firstRow = reapetsStr("#", (n - 2) - i)
                        + "." + reapetsStr(" ", 3 + i * 2) + "."
                        + reapetsStr("#", (n - 2) - i);
                System.out.println(firstRow);
            }
        }






        String edge = "@" + reapetsStr("=", n * 2 - 1) + "@";
        System.out.println(edge);

        if (n % 2 == 0) {
            for (int i = 1; i <= (n / 2) + 1; i++) {
                if (i == (n / 2) + 1) {
                    String last = reapetsStr("#", n / 2 + 1) + "\\"
                            + reapetsStr(".", n - 3) + "/"
                            + reapetsStr("#", n / 2 + 1);
                    System.out.println(last);
                } else {
                    String last = reapetsStr("#", n / 2 + 1) + "|"
                            + reapetsStr(" ", n - 3) + "|"
                            + reapetsStr("#", n / 2 + 1);
                    System.out.println(last);
                }
            }
        } else {
            for (int i = 1; i <= (n / 2) + 1; i++) {
                if (i == (n / 2) + 1) {
                    String last = reapetsStr("#", n / 2 + 2) + "\\"
                            + reapetsStr(".", n - 4) + "/"
                            + reapetsStr("#", n / 2 + 2);
                    System.out.println(last);
                } else {
                    String last = reapetsStr("#", n / 2 + 2) + "|"
                            + reapetsStr(" ", n - 4) + "|"
                            + reapetsStr("#", n / 2 + 2);
                    System.out.println(last);
                }
            }
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
