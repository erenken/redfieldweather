export class MenuItem {
  displayName: string;
  route: string;
}

export const MenuItems: MenuItem[] = [
  { displayName: 'Current Weather', route: '/current' },
  { displayName: 'About', route: '/about' },
];
