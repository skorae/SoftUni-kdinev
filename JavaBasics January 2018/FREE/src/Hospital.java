import java.util.Scanner;

public class Hospital {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        int n = Integer.parseInt(scanner.nextLine());
        int doctors = 7;
        int treatedPatients = 0;
        int unTreatepatients= 0;



        for (int i = 1; i <= n; i++) {
            int patient = Integer.parseInt(scanner.nextLine());

            if ((i % 3 == 0) && (unTreatepatients > treatedPatients)) {
                doctors++;
            }
            if (patient <= doctors){
                treatedPatients += patient;
            }
            if (patient > doctors){
                treatedPatients += doctors;
                unTreatepatients += patient - doctors;
            }
        }
        System.out.printf("Treated patients: %d.\n", treatedPatients);
        System.out.printf("Untreated patients: %d.", unTreatepatients);
    }
}
