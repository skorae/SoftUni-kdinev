import java.util.Scanner;

public class Diamond {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);


        int n = Integer.parseInt(scanner.nextLine());
        int outDots = n;
        int innDots = (3 * n) - 2;
        String firstline = "";


        for (int i = n; i > 1; i--) {
            if (i == n) {
                firstline = reapetsStr(".", outDots)
                        + "*" + reapetsStr("*", innDots) + "*"
                        + reapetsStr(".", outDots);
                outDots -= 1;
                innDots += 2;
                System.out.println(firstline);
            }
            firstline = reapetsStr(".", outDots)
                    + "*" + reapetsStr(".", innDots) + "*"
                    + reapetsStr(".", outDots);
            outDots -= 1;
            innDots += 2;
            System.out.println(firstline);
        }
        String middle = reapetsStr("*", 5 * n);
        System.out.println(middle);

        for (int i = 0; i < (2 * n); i++) {
            outDots += 1;
            innDots -= 2;
            String last = reapetsStr(".", outDots) + "*"
                    + reapetsStr(".", innDots) + "*"
                    + reapetsStr(".", outDots);
            System.out.println(last);

        }
        outDots += 1;
        innDots -= 2;
        String finalLine = reapetsStr(".", outDots) + "*"
                + reapetsStr("*", innDots) + "*"
                + reapetsStr(".", outDots);
        System.out.println(finalLine);
    }

    static String reapetsStr(String strToRepeat, int count) {
        String text = "";
        for (int i = 0; i < count; i++) {
            text += strToRepeat;
        }
        return text;
    }
}
