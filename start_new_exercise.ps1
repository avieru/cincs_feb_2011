param($message)

function format_time_as_new_branch_name
{
}

function get_latest_on_new_branch($branch_name)
{
  git add -A
  git commit -m "Committing"
  git checkout master
  git checkout -b format_time_as_new_branch_name
  git pull jp master
}

$now = get-date
$new_branch_name = "$($now.year)$($now.month)$($now.day)$($now.hour)$($now.minute)"
git add -A
git commit -m "Committing"
git checkout master
git checkout -b $new_branch_name
git pull jp master
echo "new branch name:$new_branch_name"
