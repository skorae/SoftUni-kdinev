import java.util.Scanner;

public class ButterFly {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);


        int n = Integer.parseInt(scanner.nextLine());

        for (int i = 1; i <= n - 2; i++) {
            if (i % 2 == 1) {
                String srars = reapetsStr("*", n - 2) + "\\"
                        + " " + "/" + reapetsStr("*", n - 2);
                System.out.println(srars);
            }else{
                String dashes = reapetsStr("-", n -2) + "\\"
                        + " " + "/" + reapetsStr("-", n -2);
                System.out.println(dashes);
            }
        }
        String middle = reapetsStr(" ", n - 1) + "@" + reapetsStr(" ", n -1);
        System.out.println(middle);

        for (int i = 1; i <= n - 2; i++) {
            if (i % 2 == 1) {
                String srars = reapetsStr("*", n - 2) + "/"
                        + " " + "\\" + reapetsStr("*", n - 2);
                System.out.println(srars);
            }else{
                String dashes = reapetsStr("-", n -2) + "/"
                        + " " + "\\" + reapetsStr("-", n -2);
                System.out.println(dashes);
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
