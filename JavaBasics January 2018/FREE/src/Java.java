import java.util.Scanner;

public class Java {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);


        int n = Integer.parseInt(scanner.nextLine());
        String middle = "";

        for (int i = 0; i < n; i++) {
            String first = reapetsStr(" ", n) + reapetsStr("~ ", 3);
            System.out.println(first);
        }

        String cupEdge = reapetsStr("=", n * 3 + 5);
        System.out.println(cupEdge);

        for (int i = 0; i < n - 2; i++) {
            if (i == Math.ceil((n - 2) / 2)){
                middle = "|" + reapetsStr("~", n) + "JAVA" + reapetsStr("~", n)
                        + "|" + reapetsStr(" ", n - 1) + "|";
                System.out.println(middle);
            }else{
                middle = "|" + reapetsStr("~", (n * 2) + 4) + "|"
                        + reapetsStr(" ", n - 1) + "|";
                System.out.println(middle);
            }
        }
        System.out.println(cupEdge);

        for (int i = 0; i < n; i++) {
            String cup = reapetsStr(" ", i) + "\\" + reapetsStr("@", ((n * 2) + 4) - 2 * i)
                    + "/";
            System.out.println(cup);
        }

        String last = reapetsStr("=", (n * 2) + 6);
        System.out.println(last);
    }

    static String reapetsStr(String strToRepeat, int count) {
        String text = "";
        for (int i = 0; i < count; i++) {
            text += strToRepeat;
        }
        return text;
    }
}
